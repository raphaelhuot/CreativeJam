using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardHolder : MonoBehaviour {

    public CardList cardList;
    public GameObject card;
    public InputController controller;
    public PlayersState playersState; 

    public int xBoardSize;
    public int yBoardSize; 
    public List<Vector2> cardPosition = new List<Vector2>(); 
    public int minDist;

    private void Start()
    {
        controller = GetComponent<InputController>();
        playersState = GetComponent<PlayersState>(); 
        GenerateCards();
    }

    private void GenerateCards()
    {
        for (int i = 0; i < cardList.cardList.Count; i++)
        {
            Vector3 cardPos = cardPosition[i]; 
            GameObject newCard = Instantiate(card, cardPos, Quaternion.identity);
            CardDataHolder cardData = newCard.GetComponent<CardDataHolder>();
            cardData.type = cardList.cardList[i].cardType;
            cardData.cardSprite = cardList.cardList[i].cardAsset;
            controller.cards.Add(cardData); 
        }
        playersState.InitializeCards(); 
    }

}
