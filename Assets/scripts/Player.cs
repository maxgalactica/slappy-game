using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] GameObject bullet;

    Vector2 moveValue;

    float tVal;

    Vector3 startPos = Vector3.zero;

    int player = 0;

    private void Awake()
    {
        startPos = transform.position;
    }

    public virtual void Move(InputAction.CallbackContext ctx)
    {

    }

    public void MoveP2(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            tVal = ctx.ReadValue<float>();
            transform.position = new Vector3(startPos.x + tVal, startPos.y, startPos.z);
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