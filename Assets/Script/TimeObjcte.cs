using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeObjcte : MonoBehaviour
{
    [SerializeField] float m_addTime = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager gm = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();
            gm.AddTime(m_addTime);
            Destroy(this.gameObject);
        }
    }

}
