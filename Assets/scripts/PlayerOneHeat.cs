using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOneHeat : MonoBehaviour
{
    Player player;

    float limit = 100;
    float intensity = 3f;

    Vector3 newShakePos = Vector3.zero;

    Coroutine addHeatRoutine;
    Coroutine removeHeatRoutine;

    public bool heating = false;
    [SerializeField] float currentHeat;

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    public float GetHeat()
    {
        return currentHeat;
    }

    public void StartHeating()
    {
        if (!heating)
        {
            heating = true;
            addHeatRoutine = StartCoroutine(AddHeat());
        }
    }

    public void StopHeating()
    {
        if (heating)
        {
            heating = false;
            StopCoroutine(AddHeat());
            removeHeatRoutine = StartCoroutine(RemoveHeat());
        }
    }

    IEnumerator AddHeat()
    {
        while (heating)
        {
            currentHeat += 1 * Time.deltaTime;

            if (currentHeat > 5)
            {
                player.StartRest();
                yield break;
            }
            else yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator RemoveHeat()
    {
        while(currentHeat > 0)
        {
            currentHeat -= 1 * Time.deltaTime;

            yield return new WaitForEndOfFrame();
        }
    }
}