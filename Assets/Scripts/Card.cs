using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Card
{
    [SerializeField] private string CardName;
    [SerializeField] private int CardValue;
    public string Get_CardName()
    {
        return CardName;
    }
    public int Get_CardDate()
    {
        return CardValue;
    }
}