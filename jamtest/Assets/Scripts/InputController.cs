using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour {

    public PlayersState players; 
    public LayerMask cardLayer;
    public List<CardDataHolder> selectedCards = new List<CardDataHolder>();
    public List<CardDataHolder> cards = new List<CardDataHolder>(); 

	// Use this for initialization
	void Start () {
        players = GetComponent<PlayersState>(); 
	}
	
	// Update is called once per frame
	void Update ()
    {
        SelectCard();

        RaycastHit hitInfo;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        bool hit = Physics.Raycast(ray, out hitInfo, cardLayer); 
        if (hit)
        {
            CardDataHolder card = hitInfo.transform.gameObject.GetComponent<CardDataHolder>();
            if (card.cardState == CardDataHolder.CardState.Hidden)
            {
                card.cardState = CardDataHolder.CardState.Hovered; 
                card.UpdateSprite();
                for (int i = 0; i < cards.Count; i++)
                {
                    if (cards[i] != card)
                    {
                        if (cards[i].cardState != CardDataHolder.CardState.Selected)
                        {
                            if (cards[i].cardState != CardDataHolder.CardState.Used)
                            {
                                cards[i].cardState = CardDataHolder.CardState.Hidden;
                                cards[i].UpdateSprite();
                            }
                        }
                    }
                }
            }
        }
	}

    private void SelectCard()
    {
        if (Input.GetMouseButtonDown(0))
        {
            bool allfalse = true; 
            foreach (CardDataHolder card in cards)
            {
                bool b = card.isCrRunning; 
                if (b)
                {
                    allfalse = false; 
                    break; 
                }
            }
            if (allfalse)
            {
                RaycastHit hitInfo;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                bool hit = Physics.Raycast(ray, out hitInfo, cardLayer);
                if (hit)
                {
                    CardDataHolder currentCard = hitInfo.transform.gameObject.GetComponent<CardDataHolder>();
                    if (currentCard.cardState == CardDataHolder.CardState.Hovered)
                    {
                        currentCard.isHovered = false;
                        currentCard.isSelected = true;
                        currentCard.cardState = CardDataHolder.CardState.Selected;
                        currentCard.UpdateSprite();
                        selectedCards.Add(currentCard);
                    }

                    for (int i = 0; i < selectedCards.Count; i++)
                    {
                        //selectedCards[i].UpdateSprite();
                    }
                }
            }
        }
    }

    public void CheckForCards()
    {
        if (selectedCards.Count == 2)
        {
            if (selectedCards[0].type == selectedCards[1].type)
            {
                Debug.Log("Pair");
                ResetPair(true);
            }
            else
            {
                Debug.Log("Wrong Pair");
                ResetPair(false); 
            }
        }
    }

    private void ResetPair(bool isPaired)
    {
        for (int i = 0; i < selectedCards.Count; i++)
        {
            if (isPaired)
            {
                selectedCards[i].cardState = CardDataHolder.CardState.Used;
                selectedCards[i].UpdateSprite(); 
            }
            else
            {
                StartCoroutine(selectedCards[i].flipCardBack(2f, 180f));
            }
        }

        selectedCards.Clear();
    }
}
