using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerInput : MonoBehaviour
{
    public GameObject pivotPos;

    public TextMeshProUGUI debugTextTop;
    public TextMeshProUGUI debugTextMiddle;

    public bool leftHand = false;

    public bool debugMode = false;

    public float quaternionTest = 0f;

    float degPerFrame = 180f;
    float triggerValue = 0f;
    float triggerValueL = 0f;
    float triggerValueR = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnMove(InputValue value)
    {
        //if (leftHand) triggerValue = value.Get<float>();
        //else triggerValue = -value.Get<float>();

        // if(Gamepad.current.)

        triggerValue = value.Get<float>();
    }

    // Update is called once per frame
    void Update()
    {
        if (debugMode)
        {
            debugTextTop.text = Gamepad.current.rightTrigger.EvaluateMagnitude().ToString();
            debugTextMiddle.text = triggerValue.ToString();
        }

        TestRotationGamepadTrigger();
    }

    void TestRotationGamepadTrigger()
    {
        if (leftHand) pivotPos.transform.rotation = Quaternion.Euler(triggerValue * -180, 0, 0);
        else pivotPos.transform.rotation = Quaternion.Euler(triggerValue * 180, 0, 0);
    }
}