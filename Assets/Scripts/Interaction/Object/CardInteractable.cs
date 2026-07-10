using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardInteractable : MonoBehaviour, IInteractable
{
    private CardParts cardParts;
    private CardInspectPopUp cardInspectPopUp;
    private Decisioner decisioner;
    
    void Start()
    {
        cardParts = GetComponent<CardParts>();
        cardInspectPopUp = FindObjectOfType<CardInspectPopUp>(true);
        decisioner = FindObjectOfType<Decisioner>();
    }

    public void OnSelect()
    {
        cardInspectPopUp.OpenPopUp(cardParts.npcData);
    }
}