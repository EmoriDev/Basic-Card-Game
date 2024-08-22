using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Table : MonoBehaviour
{
    public static Table instance;
    [System.Serializable]
    public struct TableCardStruct
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
        public TableCardStruct(Card c, GameObject v)
        {
            InternalCard = c;
            VisualCard = v;
        }
    }
    [SerializeField] private List<TableCardStruct> TableCards = new List<TableCardStruct>();
    [SerializeField] private Transform TablePivot;
    void Start()
    {
        instance = this;
    }
    public void SetNewCard(Card card, GameObject visual, int posit)
    {
        // place card on table
        if (posit >= TableCards.Count) posit = TableCards.Count;
        GameObject TableCardVisual = Instantiate(visual, TablePivot.position + new Vector3(posit / 1.5f, 0, -posit / 100f), Quaternion.identity);
        TableCardStruct TC = new TableCardStruct(card, TableCardVisual); ;
        TC.Get_VisualCard().GetComponent<SpriteRenderer>().color = Color.white;
        TableCards.Insert(posit,TC);
        TableCardVisual.transform.SetParent(TablePivot);
        TableCardVisual.GetComponent<PlayCard>().Set_Index(posit + 1); // set card position on table
        // deactivate table placement buttons
        TableCardVisual.GetComponentInChildren<Button>().enabled = false;
        DeckAdministrator.instance.TurnPlaceCardButtons(false);
        TurnTableButtons(false, null);
        //Alter position of the next cards on table
        int i = posit+1;
        while (i < TableCards.Count)
        {
            TableCards[i].Get_VisualCard().transform.position += new Vector3(1 /1.5f, 0, -1 / 100f);
            TableCards[i].Get_VisualCard().GetComponent<PlayCard>().Set_Index(i+1);
            i++;
        }
        // change button of the card to be a play card function
        TableCardVisual.GetComponentInChildren<Button>().onClick.AddListener(delegate () { TableCardVisual.GetComponentInChildren<PlayCard>().PlayCardOnTable(); }); 
    }
    // turn on/off buttons used to place card on table
    public void TurnTableButtons(bool value, Hand.HandClass card)
    {
        foreach (TableCardStruct tb in TableCards)
        {
            tb.Get_VisualCard().GetComponentInChildren<Button>().enabled = value;
            if (value == true)
            {
                tb.Get_VisualCard().GetComponentInChildren<PlayCard>().Set_card(card);
                tb.Get_VisualCard().GetComponent<SpriteRenderer>().color = Color.yellow;
            }
            else tb.Get_VisualCard().GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
}
