using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Countdown : MonoBehaviour
{
    public float ctdwnTimeRnd;
    public float startingCountdown;

    AudioSource beepNoise;

    Coroutine timerRoutine;

    public TextMeshProUGUI countdownText;

    private void Start()
    {
        beepNoise = GetComponent<AudioSource>();

        startingCountdown = Random.Range(1f, 15f);
        Debug.Log(startingCountdown);

        StartTimer();
    }

    public void StartTimer()
    {
        timerRoutine = StartCoroutine(RoundTimer());
    }

    IEnumerator RoundTimer()
    {
        yield return new WaitForSeconds(1);

        countdownText.text = "3...";
        yield return new WaitForSeconds(1);

        countdownText.text = "2...";
        yield return new WaitForSeconds(1);

        countdownText.text = "1...";

        yield return new WaitForSeconds(startingCountdown);

        beepNoise.Play();
        countdownText.text = "GO!!!!";
    }
}