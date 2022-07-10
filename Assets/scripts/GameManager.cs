using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    // get references to players
    public GameObject p1GO;
    public GameObject p2GO;

    private Player p1;
    private Player p2;
    
    public TextMeshProUGUI debugText;

    // hysterisis values
    float h1 = 0.4f;
    float h2 = 0.6f;

    float playerOneTVal = 0f;
    float playerTwoTVal = 0f;

    private void Awake()
    {

    }

    private void Start()
    {
        p1 = p1GO.GetComponent<Player>();
        p2 = p2GO.GetComponent<Player>();
    }

    private void Update()
    {
        debugText.text = $"P1 {p1.TVal} : P2 {p2.TVal}";
    }
}
