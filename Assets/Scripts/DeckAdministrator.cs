using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DeckAdministrator : MonoBehaviour
{
    [SerializeField] private List<Card> Deck = new List<Card>();
    [SerializeField] private Hand mainHand;
    [SerializeField] private GameObject Card;

    public static DeckAdministrator instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
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
    public void FillHandSingle()
    {
        if (mainHand.Get_CardOnHandNum() < mainHand.Get_HandMaxSize() && Deck.Count > 0)
        {
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
