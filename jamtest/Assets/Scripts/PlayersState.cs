using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersState : MonoBehaviour {

    public List<Player> players = new List<Player>();
    InputController controller; 

    public int playerBaseHealth;
    public int currPlayer = 0;

    public bool canPlay = false; 
    public float beginningTimer; 
    public float Timer;

    private void Awake()
    {
        controller = FindObjectOfType<InputController>(); 
    }

    private void Start()
    {
       InitializePlayers();
    }

    private void InitializePlayers()
    {
        for (int i = 0; i < 2; i++)
        {
            players.Add(new Player(playerBaseHealth, i));
            Debug.Log(players[i].iD); 
        }
    }

    public void InitializeCards()
    {
        if (controller.cards != null)
        {
            for (int i = 0; i < controller.cards.Count; i++)
            {
                StartCoroutine(controller.cards[i].FlipCard(2f, 0)); 
            }
        }
        StartCoroutine(StartTimer(beginningTimer));
    }

    public void FlipCardBack()
    {
        if (controller.cards != null)
        {
            for (int i = 0; i < controller.cards.Count; i++)
            {
                StartCoroutine(controller.cards[i].FlipCardBack(2f, 180));
            }
        }
        canPlay = true; 
    }

    public IEnumerator StartTimer(float timer)
    {
        yield return new WaitForSeconds(timer);
        FlipCardBack();
    }

    public void SwitchPlayer()
    {
        if (currPlayer == 0)
        {
            currPlayer = 1;
        }
        else
            currPlayer = 0; 
    }
}
