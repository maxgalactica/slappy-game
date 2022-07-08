using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [Space(10)]
    [Header("PLAYER 1")]
    public GameObject pivotPosL;
    public GameObject pivotPosR;

    [Space(5)]

    public GameObject p1HandL;
    public GameObject p1HandR;

    [Space(10)]
    [Header("PLAYER 2")]
    public GameObject p2HandL;
    public GameObject p2HandR;

    [Space(10)]

    [Header("OTHER")]
    public Collider hitboxP1;
    public Collider hitBoxP2;
    public Rigidbody rb;

    [SerializeField] float pullbackDistance = 1.2f;
    [SerializeField] float speed;
    [SerializeField] float hitboxThreshold;

    float tVal;

    bool isDead = false;

    Vector3 startPosL, startPosR, respawnPos = Vector3.zero;

    private void Update()
    {
        Debug.Log(hitboxP1.enabled);
        Debug.Log(hitBoxP2.enabled);
    }

    private void Awake()
    {
        startPosL = p2HandL.transform.position;
        startPosR = p2HandR.transform.position;

        respawnPos = transform.position;

        hitboxP1.enabled = false;
    }

    // Keep this around for reference
    public virtual void Move(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            //transform.RotateAround(piv)
        }
    }

    // On the Player Input component, the FIRE input action is the right trigger, too scared of breaking everything to rename it

    public void MoveP1L(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            tVal = ctx.ReadValue<float>();

            if (tVal > hitboxThreshold && !hitboxP1.enabled) hitboxP1.enabled = true;
            if (tVal < hitboxThreshold && hitboxP1.enabled) hitboxP1.enabled = false;

            pivotPosL.transform.rotation = Quaternion.Euler(tVal * 180, 0, 0);
        }

        if (ctx.canceled) pivotPosL.transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    public void MoveP1R(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            tVal = ctx.ReadValue<float>();
            pivotPosR.transform.rotation = Quaternion.Euler(tVal * -180, 0, 0);
        }

        if (ctx.canceled) pivotPosL.transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    public void MoveP2L(InputAction.CallbackContext ctx)
    {
        if (!isDead)
        {
            if (ctx.performed)
            {
                tVal = ctx.ReadValue<float>();
                p2HandL.transform.position = new Vector3(startPosL.x - (tVal * pullbackDistance), startPosL.y, startPosL.z);
            }
            }
    }

    public void MoveP2R(InputAction.CallbackContext ctx)
    {
        if (!isDead)
        {
            if (ctx.performed)
            {
                tVal = ctx.ReadValue<float>();
                p2HandR.transform.position = new Vector3(startPosR.x - (tVal * pullbackDistance), startPosR.y, startPosR.z);
            }
        }
    }

    // bound to right trigger on the gamepad by default if the input action asset is initialized through the player input component
    public void Shoot(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            //GameObject.Instantiate(bullet, transform.position, Quaternion.identity);
        }
    }

    public void Respawn(InputAction.CallbackContext ctx)
    {
        if (isDead)
        {
            Debug.Log("Are we getting here?");
            rb.isKinematic = true;
            transform.position = respawnPos;
            transform.rotation = Quaternion.Euler(0, 180, 0);

            isDead = false;
            //GetComponent<PlayerInput>().enabled = true;
        }
    }

    public void Die()
    {
        if (!isDead)
        {
            isDead = true;

            //GetComponent<PlayerInput>().enabled = false;

            rb.isKinematic = false;
            rb.AddForce(Vector3.back * 5, ForceMode.Impulse);
        }
    }

    // gates the hitbox from being enabled below the threshold
    void HitboxGate(GameObject box, float threshold, float value)
    {
        bool x = value > threshold ? true : false;
        box.SetActive(x);
    }
}