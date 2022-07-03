using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public GameObject plyHand;

    public GameObject pivotPos;

    public float rotSpeed = 0f;

    float degToTurn;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.fKey.isPressed)
        {
            // TestRotation();
        }

        Debug.Log(Gamepad.current.rightTrigger.ReadValue().ToString());
    }


}