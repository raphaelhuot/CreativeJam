using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Card", menuName = "Card/Create Card", order = 1)]
public class CardData : ScriptableObject
{
    public Sprite cardAsset;
    public CardType cardType; 
    public enum CardType {attack, defense, locker, vampire, timer};
}