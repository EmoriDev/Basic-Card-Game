using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    struct HandStruct
    {
        [SerializeField] private Card InternalCard;
        [SerializeField] private GameObject VisualCard;

        public Card Get_InternalCard()
        {
            return InternalCard;
        }
        public GameObject Get_VisualCard()
        {
            return VisualCard;
        }

        public HandStruct(Card c, GameObject v)
        {
            InternalCard = c;
            VisualCard = v;
        }
    }
    [SerializeField] private List<HandStruct> HandDeck = new List<HandStruct>();
    [SerializeField] private int HandStartSize = 5;
    
    public void Set_Hand(Card card, GameObject visual)
    {
        HandDeck.Add(new HandStruct(card, visual));
    }
    public int Get_HandMaxSize()
    {
        return HandStartSize;
    }
    public int Get_CardOnHandNum()
    {
        return HandDeck.Count;
    }
    public void SendHandBackToDeck()
    {
        foreach(HandStruct card in HandDeck)
        {
            DeckAdministrator.instance.FillDeck(card.Get_InternalCard());
            Destroy(card.Get_VisualCard());
        }
        HandDeck.Clear();
    }
}