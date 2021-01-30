using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySclipt : MonoBehaviour
{
    [SerializeField] EnemyDataObject m_enemyData;
   // [SerializeField] int m_initHP = 100;
    //[SerializeField] int m_score = 100;
   // [SerializeField] GameObject m_target;
    //エネミーがターゲットの位置を更新するために必要な移動距離
    [SerializeField] float m_updateMag;
    int m_nowHP;
    NavMeshAgent m_agent;
    // Start is called before the first frame update
    void Start()
    {
        m_nowHP = m_enemyData.GetEnemyData(0).InitHP;
        m_agent = GetComponent<NavMeshAgent>();
        m_enemyData.GetEnemyData(0).SetTarget();
        m_agent.SetDestination(m_enemyData.GetEnemyData(0).TargetPos);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDestination();
    }

    private void UpdateDestination()
    {
        if (Vector3.Distance(m_agent.destination, m_enemyData.GetEnemyData(0).TargetPos) > m_updateMag)
        {
            m_agent.SetDestination(m_enemyData.GetEnemyData(0).TargetPos);
        }
    }

    public void Damage(int damage) 
    {
        m_nowHP -= damage;
        CheckHP();
    }

    private void CheckHP()
    {
        if (m_nowHP <= 0)
        {
            Destroy();
        }
    }

    private void Destroy()
    {
        GameManager gm = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();
        gm.AddScore(m_enemyData.GetEnemyData(0).Score);
        Destroy(this.gameObject);
    }

    private void FindPlayer()
    {
       // m_target = GameObject.FindGameObjectWithTag("Player");
    }
}
