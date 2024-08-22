using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayCard : MonoBehaviour
{
    [SerializeField] private Hand.HandClass Card;
    [SerializeField] private int index = 0;
    public void Set_card(Hand.HandClass hand)
    {
        Card = hand;
    }
    public void Set_Index(int i)
    {
        index = i;
    }
    // button will select this card to play on the table
    public void SelectCard()
    {
        if (Card.Get_is_selected() == false) DeckAdministrator.instance.Set_SelectedCard(Card);
        else DeckAdministrator.instance.DeactivateSelection();
    }
    // button will select this card as a position on the table to place the selected card
    public void PlayCardOnTable()
    {
        if (Card.Get_VisualCard() != null)
        {
            Table.instance.SetNewCard(Card.Get_InternalCard(), Card.Get_VisualCard(), index);
            DeckAdministrator.instance.Get_Hand().RemoveCard(Card);
        }
    }
}
