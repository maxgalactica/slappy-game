using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] GameObject bullet;

    Vector2 moveValue;

    public virtual void Move(InputAction.CallbackContext ctx)
    {
        moveValue = ctx.ReadValue<Vector2>() * speed * Time.deltaTime;
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
        transform.Translate(moveValue);
    }
}