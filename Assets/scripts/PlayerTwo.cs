using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerTwo : MonoBehaviour
{
    Rigidbody rb;

    Vector3 respawnPos = Vector3.zero;
    Vector3 realForcePos = Vector3.zero;
    [SerializeField] int forcePos = 1;

    public bool isDead = false;
    [SerializeField] bool spawnProtection = false;

    MeshRenderer[] mats;

    Player p2Movement;

    private void Awake()
    {
        mats = GetComponentsInChildren<MeshRenderer>();
        p2Movement = GetComponent<Player>();
        rb = GetComponent<Rigidbody>();
        respawnPos = transform.position;
    }

    private void Start()
    {
        //for(int i = 0; i < mats.Length; ++i)
        //{
        //    Debug.Log(mats[i]);
        //}
    }

    public void Respawn(InputAction.CallbackContext ctx)
    {
        if (isDead)
        {
            isDead = false;
            StartCoroutine(SpawnProtection());

            rb.isKinematic = true;
            transform.position = respawnPos;
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    public void Die()
    {
        //Debug.Log("Can I die right now??");
        if (!isDead && !spawnProtection)
        {
            //Debug.Log("oh no, I'm dead!");
            isDead = true;
            rb.isKinematic = false;
            realForcePos = new Vector3(transform.position.x + forcePos, transform.position.y, transform.position.z);
            rb.AddForce(Vector3.left * 20, ForceMode.Impulse);
            //Debug.Log("and now I've exploded, how dreadful!");
        }
        //else Debug.Log("Nope! Still protected!");
    }

    IEnumerator SpawnProtection()
    {
        spawnProtection = true;

        for (int i = 0; i < mats.Length; ++i)
        {
            var tempAlpha = 0.5f;
            var col = mats[i].material.color;
            col.a = tempAlpha;

            mats[i].material.color = col;
        }

        yield return new WaitForSeconds(3f);

        for (int i = 0; i < mats.Length; ++i)
        {
            var tempAlpha = 1f;
            var col = mats[i].material.color;
            col.a = tempAlpha;

            mats[i].material.color = col;
        }

        spawnProtection = false;
    }
}