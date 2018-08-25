using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Card List", menuName = "Card/Card List", order = 2)]
public class CardList : ScriptableObject {

    public List<CardData> cardList = new List<CardData>(); 
}
