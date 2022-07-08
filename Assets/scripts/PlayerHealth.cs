using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    Collider hitbox;

    public Player ply;

    private void Awake()
    {
        hitbox = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter method began");

        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Other object tagged as player!");
            other.gameObject.GetComponentInParent<Player>().Die();
        }
    }
}