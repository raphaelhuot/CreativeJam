using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MatchManager : MonoBehaviour {

    public int whosTurn;

    public Text PlayerOne;
    public Text PlayerTwo;


    private void Update()
    {
        if (whosTurn == 1)
        {
            PlayerOne.color = new Color(1, 0, 0, 1);
            PlayerTwo.color = new Color(0, 0, 1, 0.2f);
        }
        else
        {
            PlayerOne.color = new Color(1, 0, 0, 0.2f);
            PlayerTwo.color = new Color(0, 0, 1, 1f);
        }
    }
}
