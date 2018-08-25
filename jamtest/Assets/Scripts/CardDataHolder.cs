using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDataHolder : MonoBehaviour {

    public Sprite cardBack; 
    public Sprite cardSprite;
    public CardData.CardType type;

    //Card States
    public bool isHidden;
    public bool isSelected;
    public bool isHovered; 
    public Color selectedCardColor;
    public Color baseCardColor;
    public Color hoveringCardColor; 

    private void Start()
    {
        isHidden = true;
        isSelected = false; 
    }

    private void Update()
    {

    }

    public void UpdateSprite()
    {
        if (isHidden)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = cardBack; 
        }
        else if (!isHidden)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = cardSprite;
        }

        if (isSelected)
        {
            gameObject.GetComponent<SpriteRenderer>().color = selectedCardColor;
            isHovered = false; 

        }
        else if (!isSelected)
        {
            gameObject.GetComponent<SpriteRenderer>().color = baseCardColor; 
        }

        if (isHovered)
        {
            gameObject.GetComponent<SpriteRenderer>().color = hoveringCardColor;

        }
        else if (!isHovered)
        {
            gameObject.GetComponent<SpriteRenderer>().color = baseCardColor;
        }
    }

}

