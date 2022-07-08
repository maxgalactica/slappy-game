using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public GameObject pivotPosL;
    public GameObject pivotPosR;

    public GameObject p1HandL;
    public GameObject p1HandR;

    public GameObject p2HandL;
    public GameObject p2HandR;

    [SerializeField] float speed;
    [SerializeField] GameObject bullet;

    Vector2 moveValue;

    float tVal;

    Vector3 startPosL, startPosR = Vector3.zero;

    int player = 0;

    private void Awake()
    {
        startPosL = p2HandL.transform.position;
        startPosR = p2HandR.transform.position;
    }

    public virtual void Move(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            //transform.RotateAround(piv)
        }
    }

    // On the Player Input component, the FIRE input action is the right trigger, too scared of breaking everything to rename it

    public void MoveP2L(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            tVal = ctx.ReadValue<float>();
            p2HandL.transform.position = new Vector3(startPosL.x + tVal, startPosL.y, startPosL.z);
        }
    }

    public void MoveP2R(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            tVal = ctx.ReadValue<float>();
            p2HandR.transform.position = new Vector3(startPosR.x + tVal, startPosR.y, startPosR.z);
        }
    }

    public void Shoot(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            GameObject.Instantiate(bullet, transform.position, Quaternion.identity);
        }
    }

    private void Update()
    {
        //transform.position = new Vector3(startPos.x + tVal, startPos.y, startPos.z);
    }
}