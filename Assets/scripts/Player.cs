using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    PlayerHandControls controls;

    public GameObject pivotPos;
    public TextMeshProUGUI debugTextTop;
    public TextMeshProUGUI debugTextMiddle;

    private void Awake()
    {
        controls = new PlayerHandControls();

        controls.Hand.MoveLeftHand.performed += ctx => MoveLeft();

        controls.Hand.MoveLeftHand.performed += ctx => MoveRight();
    }

    void MoveLeft()
    {

    }

    void MoveRight()
    {

    }

    private void OnEnable()
    {
        controls.Hand.Enable();
    }

    private void OnDisable()
    {
        controls.Hand.Disable();
    }
}