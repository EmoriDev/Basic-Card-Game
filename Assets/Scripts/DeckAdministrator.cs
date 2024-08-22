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
        //FillHand(mainHand.Get_HandMaxSize());
        instance = this;
    }
    public void FillDeck(Card card)
    {
        Deck.Add(card);
    }

    //Fill
    public void FillHand(int HandSize)
    {
        if (mainHand.Get_CardOnHandNum() > 0)
        {
            mainHand.SendHandBackToDeck();
        }
        for(int i = 0; i< HandSize; i++)
        {
            // set card
            int index = Random.Range(0, Deck.Count);
            GameObject obj = Instantiate(Card, new Vector3(-7.5f + (3.75f * i), -3, 0), Quaternion.identity);
            obj.GetComponentInChildren<TMP_Text>().text = Deck[index].Get_CardName();
            mainHand.Set_Hand(Deck[index], obj);
            Deck.RemoveAt(index);
        }
    }
}
