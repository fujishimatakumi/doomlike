using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySclipt : MonoBehaviour
{
    
    [SerializeField] int m_initHP = 100;
    [SerializeField] int m_score = 100;
    [SerializeField] GameObject m_target;
    //エネミーがターゲットの位置を更新するために必要な移動距離
    [SerializeField] float m_updateMag;
    int m_nowHP;
    NavMeshAgent m_agent;
    // Start is called before the first frame update
    void Start()
    {
        m_nowHP = m_initHP;
        m_agent = GetComponent<NavMeshAgent>();
        m_agent.SetDestination(m_target.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDestination();
        Debug.Log("onscript");
    }

    private void UpdateDestination()
    {
        if (Vector3.Distance(m_agent.destination,m_target.transform.position) > m_updateMag)
        {
            m_agent.SetDestination(m_target.transform.position);
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
        gm.AddScore(m_score);
        Destroy(this.gameObject);
    }
}
