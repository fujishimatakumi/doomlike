using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControlle : MonoBehaviour
{
    [SerializeField] float m_speed = 5f;
    Rigidbody m_rb;
    AttackType m_nowWepone;
    [SerializeField] Image m_closeHeare;
    [SerializeField] float m_distance;
    [SerializeField] float m_dashspeed = 8f;
    [SerializeField] LayerMask m_hitLayer;
    [SerializeField] int m_gunDamage = 100;
    public EnemySclipt EnemySclipt { get; private set; }
    GunBase m_base;
    bool m_isCursor;

    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
        m_base = GetComponent<GunBase>();
        m_nowWepone = AttackType.Gun;
        m_isCursor = false;
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
            m_rb.velocity = new Vector3(0, m_rb.velocity.y, 0);
        }
        else
        {
            dir = Camera.main.transform.TransformDirection(dir);

            dir.y = 0;
            this.transform.forward = dir;

            if (Input.GetKey(KeyCode.LeftShift))
            {
                Vector3 dashvelo = this.transform.forward * m_dashspeed;
                dashvelo.y = m_rb.velocity.y;
                m_rb.velocity = dashvelo;
            }
            else
            {
                Vector3 velo = this.transform.forward * m_speed;
                velo.y = m_rb.velocity.y;
                m_rb.velocity = velo;
            }
            

        }
    }

    private void Attack()
    {
        switch (m_nowWepone)
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
            m_nowWepone = AttackType.Gun;
            Debug.Log("getkey1");
            Debug.Log(m_nowWepone);
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            m_nowWepone = AttackType.Canon;
            Debug.Log("getkey2");
            Debug.Log(m_nowWepone);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            m_nowWepone = AttackType.Knife;
            Debug.Log("getkey3");
            Debug.Log(m_nowWepone);
        }
       
    }

    private void GunAttack()
    {
        Aim();
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(m_base.Reload());
        }
        if (Input.GetButton("Fire1"))
        {
            m_base.Fire();
        }
    }

    private void Aim()
    {
        Ray ray = Camera.main.ScreenPointToRay(m_closeHeare.rectTransform.position);
        RaycastHit hit;
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);
        if (Physics.Raycast(ray.origin, ray.direction, out hit, m_distance, m_hitLayer))
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
        if (m_isCursor)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                m_isCursor = false;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                m_isCursor = true;
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