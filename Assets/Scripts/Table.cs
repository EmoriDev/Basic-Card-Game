using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Table : MonoBehaviour
{
    public static Table instance;
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

    public void SetNewCard(Card card, GameObject visual)
    {
        GameObject TableCardVisual = Instantiate(visual, TablePivot.position + new Vector3(TableCards.Count/2f, 0, -TableCards.Count/100f), Quaternion.identity);
        TableCards.Add(new TableCardStruct(card, TableCardVisual));
        TableCardVisual.GetComponentInChildren<Button>().enabled = false;
        TableCardVisual.transform.SetParent(TablePivot);
    }
}
