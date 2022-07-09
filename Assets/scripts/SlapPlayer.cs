using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlapPlayer : MonoBehaviour
{
    Collider hitbox;

    private void Awake()
    {
        hitbox = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("OnTriggerEnter method began");

        if (other.gameObject.tag == "Player")
        {
            //Debug.Log("Other object tagged as player!");

            other.gameObject.GetComponentInParent<PlayerTwo>().Die();
        }
    }
}
