using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayCard : MonoBehaviour
{
    [SerializeField] private Hand.HandStruct Card;
    [SerializeField] private int index = 0;
    public void Set_card(Hand.HandStruct hand)
    {
        Card = hand;
    }
    public void SelectCard()
    {
        if (Card.Get_is_selected() == false) DeckAdministrator.instance.Set_SelectedCard(Card);
        else DeckAdministrator.instance.UnselectCard();
    }
    public void PlayCardOnTable()
    {
        if (Card.Get_VisualCard() != null)
        {
            Table.instance.SetNewCard(Card.Get_InternalCard(), Card.Get_VisualCard(), index);
            DeckAdministrator.instance.Get_Hand().RemoveCard(Card);
        }
    }
}
