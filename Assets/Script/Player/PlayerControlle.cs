using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControlle : MonoBehaviour
{
    [SerializeField] float _speed = 5f;
    Rigidbody _rb;
    AttackType _nowWepone;
    [SerializeField] Image _closeHeare;
    [SerializeField] float _distance;
    [SerializeField] float _dashspeed = 8f;
    [SerializeField] LayerMask _hitLayer;
    [SerializeField] int _gunDamage = 100;
    public EnemySclipt EnemySclipt { get; private set; }
    GunBase _base;
    bool _isCursor;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _base = GetComponent<GunBase>();
        _nowWepone = AttackType.Gun;
        _isCursor = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Attack();
        ChangeWepone();
        IsCursor();
    }

    private void Move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 dir = Vector3.forward * v + Vector3.right * h;

        if (dir == Vector3.zero)
        {
            _rb.velocity = new Vector3(0, _rb.velocity.y, 0);
        }
        else
        {
            dir = Camera.main.transform.TransformDirection(dir);

            dir.y = 0;
            this.transform.forward = dir;

            if (Input.GetKey(KeyCode.LeftShift))
            {
                Vector3 dashvelo = this.transform.forward * _dashspeed;
                dashvelo.y = _rb.velocity.y;
                _rb.velocity = dashvelo;
            }
            else
            {
                Vector3 velo = this.transform.forward * _speed;
                velo.y = _rb.velocity.y;
                _rb.velocity = velo;
            }
            

        }
    }

    private void Attack()
    {
        switch (_nowWepone)
        {
            case AttackType.Gun:
                GunAttack();
                break;
            case AttackType.Canon:
                CanonAttack();
                break;
            case AttackType.Knife:
                KnifeAttack();
                break;
            default:
                break;
        }
    }

    private void ChangeWepone()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _nowWepone = AttackType.Gun;
            Debug.Log("getkey1");
            Debug.Log(_nowWepone);
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            _nowWepone = AttackType.Canon;
            Debug.Log("getkey2");
            Debug.Log(_nowWepone);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _nowWepone = AttackType.Knife;
            Debug.Log("getkey3");
            Debug.Log(_nowWepone);
        }
    }

    private void GunAttack()
    {
        Aim();
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(_base.Reload());
        }
        if (Input.GetButton("Fire1"))
        {
            _base.Fire();
        }
    }

    private void Aim()
    {
        Ray ray = Camera.main.ScreenPointToRay(_closeHeare.rectTransform.position);
        RaycastHit hit;
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);
        if (Physics.Raycast(ray.origin, ray.direction, out hit, _distance, _hitLayer))
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                EnemySclipt = hit.collider.gameObject.GetComponent<EnemySclipt>();
                Debug.Log("getscript");
            }
            else
            {
                this.EnemySclipt = null;
            }
        }
        else
        {
            EnemySclipt = null;
        }
    }

    private void CanonAttack()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("getmouse");
        }
    }

    private void KnifeAttack()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("getmouse");
        }
    }

    private void IsCursor()
    {
        if (_isCursor)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                _isCursor = false;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                _isCursor = true;
            }
        }
    }
}

public enum AttackType
{ 
    Gun,
    Canon,
    Knife
}