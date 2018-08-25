using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDataHolder : MonoBehaviour {

    //Components
    SpriteRenderer sprite;
    InputController controller; 

    //Data
    public Sprite cardBack;
    public Sprite cardSprite;
    public CardData.CardType type;

    //Card States
    public bool isHidden;
    public bool isSelected;
    public bool isHovered;
    public bool isCrRunning; 
    public Color selectedCardColor;
    public Color baseCardColor;
    public Color hoveringCardColor;
    public Color usedCardColor; 
    public CardState cardState;
    public enum CardState {Hovered, Selected, Hidden, Used}

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        controller = FindObjectOfType<InputController>(); 
    }

    private void Start()
    {
        isCrRunning = false; 
        cardState = CardState.Hidden; 
        UpdateSprite(); 
    }

    private void Update()
    {

    }

    public void UpdateSprite()
    {
        Debug.Log(cardState); 
        switch (cardState)
        {
            case CardState.Hidden:
                sprite.sprite = cardBack;
                sprite.color = baseCardColor; 
                break;
            case CardState.Hovered:
                sprite.color = hoveringCardColor; 
                break;
            case CardState.Selected:
                //sprite.color = selectedCardColor;
                StartCoroutine(flipCard(10f, 0f)); 
                break;
            case CardState.Used:
                sprite.sprite = cardSprite; 
                sprite.color = usedCardColor;
                gameObject.layer = 2; 
                break; 
        }
    }

    public IEnumerator flipCard(float duration, float flip)
    {
        float elapsedTime = .0f;
        while (elapsedTime < duration && flip < 180)
        {
            isCrRunning = true;
            flip +=3f; 
            if (flip == 90)
            {
                sprite.sprite = cardSprite;
            }
            Quaternion targetRotation = Quaternion.Euler(new Vector3(0f, flip, 0f));
            transform.rotation = targetRotation;  
            yield return new WaitForEndOfFrame();
            isCrRunning = false; 
        }
        controller.CheckForCards(); 
    }

    public IEnumerator flipCardBack(float duration, float flip)
    {
        float elapsedTime = .0f;
        while (elapsedTime < duration && flip > 0)
        {
            isCrRunning = true;
            flip -= 2f;
            if (flip == 90)
            {
                sprite.sprite = cardBack;
            }
            Quaternion targetRotation = Quaternion.Euler(new Vector3(0f, flip, 0f));
            transform.rotation = targetRotation;
            yield return new WaitForEndOfFrame();
            isCrRunning = false; 
        }
        cardState = CardState.Hidden;
        UpdateSprite(); 
    }
}

