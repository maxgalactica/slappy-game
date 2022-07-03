using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerInput : MonoBehaviour
{
    public GameObject plyHand;

    public GameObject pivotPos;

    public TextMeshProUGUI debugTextTop;
    public TextMeshProUGUI debugTextMiddle;

    public float rotSpeed = 0f;

    public float quaternionTest = 0f;

    float degPerFrame = 180f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.fKey.isPressed)
        {
            TestRotation();
        }

        Debug.Log(Gamepad.current.rightTrigger.ReadValue().ToString());

        debugTextTop.text = Gamepad.current.rightTrigger.EvaluateMagnitude().ToString();
        debugTextMiddle.text = pivotPos.transform.localRotation.x.ToString();

        TestRotationGamepadTrigger();
    }

    void TestRotation()
    {
        transform.RotateAround(pivotPos.transform.position, Vector3.left, rotSpeed * Time.deltaTime);
    }

    void TestRotationGamepadTrigger()
    {
        float triggerMag = Gamepad.current.rightTrigger.EvaluateMagnitude();

        pivotPos.transform.rotation = Quaternion.Euler(triggerMag * 180, 0, 0);
    }
}