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
        cardParts.selectedOutline.SetActive(true);
        
        // Munculkan tombol action kartu saat dipilih
        if(cardParts.actionButton != null) 
            cardParts.actionButton.SetActive(true);
    }

    public void OnUnselect()
    {
        cardParts.selectedOutline.SetActive(false);
        
        // Sembunyikan tombol action kartu saat batal dipilih
        if(cardParts.actionButton != null) 
            cardParts.actionButton.SetActive(false);
    }

    public void Open()
    {
        cardInspectPopUp.OpenPopUp(cardParts.npcData);
    }

    public void CardAccept()
    {
        decisioner.ProcessCard(true);
    }

    // Fungsi yang ditempel di Button Reject khusus Kartu (Reject Semua)
    public void CardReject()
    {
        decisioner.ProcessCard(false);
    }
}