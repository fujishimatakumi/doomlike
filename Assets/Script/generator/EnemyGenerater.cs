using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerater : MonoBehaviour
{
    [SerializeField] GameObject _enemyObj;
    [SerializeField] int _enemyLimit = 30;
    [SerializeField] float _generateMargin = 1f;
    [SerializeField] Transform[] _generateTransfoems;
    [SerializeField] Transform _enemysPearent;
    float m_counter;
    // Start is called before the first frame update
    void Start()
    {
        m_counter = _generateMargin;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsRimit()) return;

        if (m_counter <= 0)
        {
            
                int posIndex = Random.Range(0, _generateTransfoems.Length);
                GameObject enemyInstans =  Instantiate(_enemyObj, _generateTransfoems[posIndex].position, Quaternion.identity);
                enemyInstans.transform.SetParent(_enemysPearent);
                enemyInstans.SetActive(true);
                m_counter = _generateMargin;
            
        }
        else
        {
            m_counter -= Time.deltaTime;
        }
    }

    private bool IsRimit()
    {
        if (_enemysPearent.transform.childCount >= _enemyLimit)
        {
            return true;
        }
        return false;
    }
}
