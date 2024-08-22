using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class DeckAdministrator : MonoBehaviour
{
    [SerializeField] private List<Card> Deck = new List<Card>();
    [SerializeField] private Hand mainHand;
    [SerializeField] private GameObject Card;
    [SerializeField] private Hand.HandClass SelectedCard;
    [SerializeField] private PlayCard TopPlaceButton;
    [SerializeField] private PlayCard BottomPlaceButton;

    public static DeckAdministrator instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        TurnPlaceCardButtons(false);
    }
    // select a card to play on table
    public void Set_SelectedCard(Hand.HandClass card)
    {
        UnselectCard();
        SelectedCard = card;
        card.Get_VisualCard().transform.position = new Vector3(card.Get_VisualCard().transform.position.x, -2, 0);
        card.Get_VisualCard().GetComponent<SpriteRenderer>().color = Color.yellow;
        card.Set_is_selected(true);
        TurnPlaceCardButtons(true);
        TopPlaceButton.Set_card(card);
        BottomPlaceButton.Set_card(card);
        Table.instance.TurnTableButtons(true, card);
    }
    // unselect a card that was presviously selected
    public void UnselectCard()
    {
        if (SelectedCard.Get_VisualCard() != null)
        {
            SelectedCard.Get_VisualCard().transform.position = new Vector3(SelectedCard.Get_VisualCard().transform.position.x, -3, 0);
            SelectedCard.Get_VisualCard().GetComponent<SpriteRenderer>().color = Color.white;
            SelectedCard.Set_is_selected(false);
        }
    }
    public void DeactivateSelection()
    {
        UnselectCard();
        TurnPlaceCardButtons(false);
        Table.instance.TurnTableButtons(false, null);
    }
    public void TurnPlaceCardButtons(bool value)
    {
        TopPlaceButton.GetComponent<Button>().enabled = value;
        TopPlaceButton.GetComponent<Image>().enabled = value;
        BottomPlaceButton.GetComponent<Button>().enabled = value;
        BottomPlaceButton.GetComponent<Image>().enabled = value;
    }
    public Hand Get_Hand()
    {
        return mainHand;
    }
    // Return a card to the deck
    public void FillDeck(Card card)
    {
        Deck.Add(card);
    }
    //Fill a hand with 5 cards
    public void FillHand(int HandSize)
    {
        if (Deck.Count > 4)
        {
            DeactivateSelection();
            if (mainHand.Get_CardOnHandNum() > 0)
            {
                mainHand.SendHandBackToDeck();
            }
            for (int i = 0; i < HandSize; i++)
            {
                // set card
                DrawCard(i);
            }
        }
    }
    //Draw a single car dto the hand
    public void FillHandSingle()
    {
        if (mainHand.Get_CardOnHandNum() < mainHand.Get_HandMaxSize() && Deck.Count > 0)
        {
            DeactivateSelection();
            DrawCard(mainHand.Get_CardOnHandNum());
        }
    }

    // Add a single card to a hand
    public void DrawCard(int cardposition)
    {
        int index = Random.Range(0, Deck.Count);
        GameObject obj = Instantiate(Card, new Vector3(-7.5f + (3.75f * cardposition), -3, 0), Quaternion.identity);
        obj.GetComponentInChildren<TMP_Text>().text = Deck[index].Get_CardName();
        mainHand.Set_Hand(Deck[index], obj);
        Deck.RemoveAt(index);
        obj.transform.SetParent(mainHand.transform);
    }
}
