using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour {

    public LayerMask cardLayer;
    public List<CardDataHolder> selectedCards = new List<CardDataHolder>();
    public List<CardDataHolder> cards = new List<CardDataHolder>(); 

	// Use this for initialization
	void Start () {
		
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
            if (card.cardState != CardDataHolder.CardState.Selected)
            {
                card.cardState = CardDataHolder.CardState.Hovered; 
                card.UpdateSprite();
                for (int i = 0; i < cards.Count; i++)
                {
                    if (cards[i] != card)
                    {
                        cards[i].cardState = CardDataHolder.CardState.Hidden;
                        cards[i].UpdateSprite();
                    }
                }
            }
        }
	}

    private void SelectCard()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            bool hit = Physics.Raycast(ray, out hitInfo, cardLayer);
            if (hit)
            {
                CardDataHolder currentCard = hitInfo.transform.gameObject.GetComponent<CardDataHolder>();
                currentCard.isHovered = false;
                currentCard.isSelected = true;
                currentCard.cardState = CardDataHolder.CardState.Selected;
                currentCard.UpdateSprite();
                selectedCards.Add(currentCard);

                if (selectedCards.Count > 1)
                {
                    selectedCards[selectedCards.Count-1].isSelected = false;
                }
                for (int i = 0; i < selectedCards.Count; i++)
                {
                    selectedCards[i].UpdateSprite();
                }
            }
        }
    }

}
