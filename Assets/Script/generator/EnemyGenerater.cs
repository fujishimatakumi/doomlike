using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerater : MonoBehaviour
{
    [SerializeField] GameObject m_enemyObj;
    [SerializeField] int m_enemyLimit = 30;
    [SerializeField] float m_generateMargin = 1f;
    [SerializeField] Transform[] m_generateTransfoems;
    [SerializeField] Transform m_enemysPearent;
    float m_counter;
    // Start is called before the first frame update
    void Start()
    {
        m_counter = m_generateMargin;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsRimit()) return;

        if (m_counter <= 0)
        {
            
                int posIndex = Random.Range(0, m_generateTransfoems.Length);
                GameObject enemyInstans =  Instantiate(m_enemyObj, m_generateTransfoems[posIndex].position, Quaternion.identity);
                enemyInstans.transform.SetParent(m_enemysPearent);
                enemyInstans.SetActive(true);
                m_counter = m_generateMargin;
            
        }
        else
        {
            m_counter -= Time.deltaTime;
        }
    }

    private bool IsRimit()
    {
        if (m_enemysPearent.transform.childCount >= m_enemyLimit)
        {
            return true;
        }
        return false;
    }
}
