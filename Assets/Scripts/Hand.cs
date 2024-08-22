using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    [SerializeField] private List<Card> HandDeck = new List<Card>();
    [SerializeField] private int HandStartSize = 5;
    public void Set_Hand(Card card)
    {
        HandDeck.Add(card);
    }
    public int Get_HandMaxSize()
    {
        return HandStartSize;
    }
}