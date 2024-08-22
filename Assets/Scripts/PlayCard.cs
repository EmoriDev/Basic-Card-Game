using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayCard : MonoBehaviour
{
    private Hand.HandStruct Card;
    public void Set_index(Hand.HandStruct hand)
    {
        Card = hand;
    }
    public void PlayCardOnTable()
    {
        Table.instance.SetNewCard(Card.Get_InternalCard(),Card.Get_VisualCard());
        DeckAdministrator.instance.Get_Hand().RemoveCard(Card);
    }
}
