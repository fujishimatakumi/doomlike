using UnityEngine;
using UnityEngine.AI;

public class EnemySclipt : MonoBehaviour
{
    [SerializeField] EnemyDataObject _enemyData;
   // [SerializeField] int m_initHP = 100;
    //[SerializeField] int m_score = 100;
   // [SerializeField] GameObject m_target;
    //エネミーがターゲットの位置を更新するために必要な移動距離
    [SerializeField] float _updateMag;
    int _nowHP;
    NavMeshAgent _agent;
    //デバック用：NavMeshAgentを使用するかどうか
    [SerializeField]static bool _isNavgation;

    public static bool IsNavgation => _isNavgation;


    //デバック用
    EnemyAnimationController _animcontroller;
    // Start is called before the first frame update
    void Start()
    {
        _nowHP = _enemyData.GetEnemyData(0).InitHP;
        _agent = GetComponent<NavMeshAgent>();
        _enemyData.GetEnemyData(0).SetTarget();
        //m_agent.SetDestination(m_enemyData.GetEnemyData(0).TargetPos);
        _animcontroller = GetComponent<EnemyAnimationController>();
    }

    // Update is called once per frame
    void Update()
    {
       if(_isNavgation) UpdateDestination();
    }

    //プレイヤーと自身の距離が_updateMagより短くなったらプレイヤーを追うのをやめる
    //Bug:_updateMagより距離が短くなってもプレイヤーを追ってしまう
    private void UpdateDestination()
    {
        if (Vector3.Distance(_agent.destination, _enemyData.GetEnemyData(0).TargetPos) > _updateMag)
        {
            _agent.SetDestination(_enemyData.GetEnemyData(0).TargetPos);
        }
    }

    /// <summary>
    /// エネミーのHPを減らす関数
    /// HPが０以下になったらデストロイする
    /// </summary>
    /// <param name="damage"></param>
    public void Damage(int damage) 
    {
        if (_nowHP - damage <= 0)
        {
            Destroy();
        }
        _nowHP -= damage;
    }

    /// <summary>
    /// エネミーオブジェクトを破棄する処理
    /// TODO：オブジェクトプールを行ったほうが良い？
    /// </summary>
    private void Destroy()
    {
        GameManager gm = FindObjectOfType<GameManager>();
        //ゲームマネージャーがない場合でもエラーをはかないようにするため（テストシーン用）
        if (gm)
        {
            gm.AddScore(_enemyData.GetEnemyData(0).Score);
        }

        //デストロイ時アニメーション処理
        EnemyAnimationController EAnimController = GetComponent<EnemyAnimationController>();
        EAnimController.OnActionParamater(EnemyActionParameterName.FallingBack);

        //Destroy(this.gameObject);
    }

    private void FindPlayer()
    {
       // m_target = GameObject.FindGameObjectWithTag("Player");
    }
}
