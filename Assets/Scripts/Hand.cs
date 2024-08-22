using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    [System.Serializable]
    public class HandStruct
    {
        [SerializeField] private Card InternalCard;
        [SerializeField] private GameObject VisualCard;
        [SerializeField] private bool is_selected;
        public bool Get_is_selected()
        {
            return is_selected;
        }
        public void Set_is_selected(bool value)
        {
            is_selected = value;
        }
        public Card Get_InternalCard()
        {
            return InternalCard;
        }
        public GameObject Get_VisualCard()
        {
            return VisualCard;
        }
        public HandStruct(Card c, GameObject v, bool s)
        {
            InternalCard = c;
            VisualCard = v;
            is_selected = s;
            VisualCard.GetComponent<PlayCard>().Set_card(this);
        }
    }
    [SerializeField] private List<HandStruct> HandDeck = new List<HandStruct>();
    [SerializeField] private int HandStartSize = 5;
    
    public void Set_Hand(Card card, GameObject visual)
    {
        HandDeck.Add(new HandStruct(card, visual,false));
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
    public void RemoveCard(HandStruct card)
    {
        int i = 0;
        while (HandDeck[i].Get_VisualCard() != card.Get_VisualCard() && i < HandDeck.Count)
        {
            i++;
        }
        HandDeck.RemoveAt(i);
        while (i < HandDeck.Count)
        {
            HandDeck[i].Get_VisualCard().transform.position -= new Vector3(3.75f, 0, 0);
            i++;
        }
        GameObject vc = card.Get_VisualCard();
        Destroy(vc);
        
    }
}