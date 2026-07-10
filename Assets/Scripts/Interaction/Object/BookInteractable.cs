using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookInteractable : MonoBehaviour, IInteractable
{
    private BookParts bookParts;
    private Decisioner decisioner;
    private BookInspectPopUp bookInspectPopUp;
    
    // Asumsi: Di BookParts Anda punya referensi ke GameObject panel tombolnya
    // atau Anda bisa langsung taruh UI-nya di prefab buku ini.

    void Start()
    {
        bookParts = GetComponent<BookParts>();
        bookInspectPopUp = FindObjectOfType<BookInspectPopUp>(true);
        decisioner = FindObjectOfType<Decisioner>();
    }

    public void OnSelect()
    {
        bookParts.selectedOutline.SetActive(true);
        
        // Munculkan tombol action buku ini saat dipilih
        if(bookParts.actionButton != null) 
            bookParts.actionButton.SetActive(true); 
    }

    public void OnUnselect()
    {
        bookParts.selectedOutline.SetActive(false);
        
        // Sembunyikan tombol action buku saat batal dipilih
        if(bookParts.actionButton != null) 
            bookParts.actionButton.SetActive(false);
    }

    public void Open()
    {
        bookInspectPopUp.OpenPopUp(bookParts.bookData);
    }

    // Fungsi yang ditempel di Button Accept khusus buku
    public void BookAccept()
    {
        decisioner.ProcessBook(bookParts, true);
    }

    // Fungsi yang ditempel di Button Reject khusus buku
    public void BookReject()
    {
        decisioner.ProcessBook(bookParts, false);
    }
}