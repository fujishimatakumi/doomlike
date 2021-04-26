using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeObjcte : MonoBehaviour
{
    [SerializeField] float _addTime = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager gm = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();
            gm.AddTime(_addTime);
            Destroy(this.gameObject);
        }
    }

}
