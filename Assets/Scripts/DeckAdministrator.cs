using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DeckAdministrator : MonoBehaviour
{
    [SerializeField] private List<Card> Deck = new List<Card>();
    [SerializeField] private Hand mainHand;
    [SerializeField] private GameObject Card;
    // Start is called before the first frame update
    void Start()
    {
        FillHand(mainHand.Get_HandMaxSize());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Fill
    public void FillHand(int HandSize)
    {
        for(int i = 0; i< HandSize; i++)
        {
            // set card on script
            int index = Random.Range(0, Deck.Count);
            mainHand.Set_Hand(Deck[index]);
            // set card on screen
            GameObject obj = Instantiate(Card, new Vector3(-7.5f + (3.75f * i), -3, 0), Quaternion.identity);
            obj.GetComponentInChildren<TMP_Text>().text = Deck[index].Get_CardName();
            Deck.RemoveAt(index);
        }
    }
}
