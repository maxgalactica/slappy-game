using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float shakeWaitTime = 1f;

    [Space(10)]
    [Header("PLAYER 1")]
    public GameObject pivotPosL;
    public GameObject pivotPosR;

    [Space(5)]

    public GameObject p1HandL;
    public GameObject p1HandR;

    public Collider hitboxP1L;
    public Collider hitBoxP1R;

    [Space(10)]
    [Header("PLAYER 2")]
    public GameObject p2HandL;
    public GameObject p2HandR;

    public Collider hitboxP2L;
    public Collider hitBoxP2R;

    [Space(10)]

    [Header("OTHER")]
    public Rigidbody rb;

    [SerializeField] float pullbackDistance = 1.2f;
    [SerializeField] float speed;
    [SerializeField] float hitboxThreshold;

    float tVal;

    bool isDead = false;

    Vector3 startPosL, startPosR, respawnPos = Vector3.zero;

    PlayerInput pInput;

    PlayerTwo p2;

    PlayerOneHeat heat;

    Coroutine restRoutine;

    [SerializeField] bool trembling = true;

    private void Update()
    {
        //Debug.Log("##PLAYER ONE## L: " + hitboxP1L.enabled + " R: " + hitBoxP1R.enabled);
        //Debug.Log("##PLAYER TWO## L: " + hitboxP2L.enabled + " R: " + hitBoxP2R.enabled);
    }

    private void Awake()
    {
        startPosL = p2HandL.transform.position;
        startPosR = p2HandR.transform.position;

        respawnPos = transform.position;

        hitboxP1L.enabled = false;
        hitBoxP1R.enabled = false;

        pInput = GetComponent<PlayerInput>();
        p2 = GetComponent<PlayerTwo>();
        heat = GetComponent<PlayerOneHeat>();
    }

    private void Start()
    {
        StartCoroutine(Tremble());
    }

    public void StartRest()
    {
        restRoutine = StartCoroutine(Rest());
    }

    // On the Player Input component, the FIRE input action is the right trigger, too scared of breaking everything to rename it

    public void MoveP1L(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            tVal = ctx.ReadValue<float>();

            // probably a better way to do this
            if (tVal > hitboxThreshold && !hitboxP1L.enabled)
            {
                hitboxP1L.enabled = true;
            }
            if (tVal < hitboxThreshold && hitboxP1L.enabled)
            {
                hitboxP1L.enabled = false;
            }

            // feel the burn (or don't)
            if (tVal > 0.1f && !heat.heating) heat.StartHeating();
            if (tVal <= 0.1f && heat.heating) heat.StopHeating();

            // actually move the hand
            pivotPosL.transform.rotation = Quaternion.Euler(tVal * 180, 0, 0);
        }

        if (ctx.canceled) pivotPosL.transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    public void MoveP1R(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            tVal = ctx.ReadValue<float>();

            if (tVal > hitboxThreshold && !hitBoxP1R.enabled) hitBoxP1R.enabled = true;
            if (tVal < hitboxThreshold && hitBoxP1R.enabled) hitBoxP1R.enabled = false;

            pivotPosR.transform.rotation = Quaternion.Euler(tVal * -180, 0, 0);
        }

        if (ctx.canceled) pivotPosL.transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    public void MoveP2L(InputAction.CallbackContext ctx)
    {
        if (ctx.performed && !p2.isDead)
        {
            tVal = ctx.ReadValue<float>();
            p2HandL.transform.position = new Vector3(startPosL.x - (tVal * pullbackDistance), startPosL.y, startPosL.z);
        }
        if (ctx.canceled && !p2.isDead)
        {
            tVal = 0;
            p2HandL.transform.position = startPosL;
        }
    }

    public void MoveP2R(InputAction.CallbackContext ctx)
    {
        if (ctx.performed && !p2.isDead)
        {
            tVal = ctx.ReadValue<float>();
            p2HandR.transform.position = new Vector3(startPosR.x - (tVal * pullbackDistance), startPosR.y, startPosR.z);
        }
        if (ctx.canceled && !p2.isDead)
        {
            tVal = 0;
            p2HandR.transform.position = startPosR;
        }
    }

    IEnumerator Tremble()
    {
        float intensity = 0.10f;

        while (trembling)
        {
            Debug.Log("In the coroutine");
            float currentHeat = heat.GetHeat() * 0.01f;

            Vector3 tempShakePos = new Vector3(
                Mathf.Clamp(Random.Range(0.0f, 0.25f) * currentHeat, 0, 0.50f),
                Mathf.Clamp(Random.Range(0.0f, 0.25f) * currentHeat, 0, 0.50f),
                Mathf.Clamp(Random.Range(0.0f, 0.25f) * currentHeat, 0, 0.50f));

            transform.localPosition += tempShakePos;
            yield return new WaitForSeconds(shakeWaitTime);
            transform.localPosition -= tempShakePos;
            yield return new WaitForSeconds(shakeWaitTime);
        }
    }

    IEnumerator Rest()
    {
        pInput.currentActionMap.Disable();

        yield return new WaitForSeconds(3f);

        pInput.currentActionMap.Enable();
    }

    // ###NOT IN USE###
    // bound to right trigger on the gamepad by default if the input action asset is initialized through the player input component
    public void Shoot(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            //GameObject.Instantiate(bullet, transform.position, Quaternion.identity);
        }
    }
}