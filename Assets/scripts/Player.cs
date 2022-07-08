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

    [SerializeField] float pullbackDistance = 1.2f;
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
        if (ctx.performed)
        {
            tVal = ctx.ReadValue<float>();
            p2HandL.transform.position = new Vector3(startPosL.x - (tVal * pullbackDistance), startPosL.y, startPosL.z);
        }
    }

    public void MoveP2R(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            tVal = ctx.ReadValue<float>();
            p2HandR.transform.position = new Vector3(startPosR.x - (tVal * pullbackDistance), startPosR.y, startPosR.z);
        }
    }

    // bound to right trigger on the gamepad by default if the input action asset is initialized through the player input component
    public void Shoot(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            GameObject.Instantiate(bullet, transform.position, Quaternion.identity);
        }
    }
}