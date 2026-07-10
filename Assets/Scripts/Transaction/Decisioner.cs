using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decisioner : MonoBehaviour
{
    private NpcController currentTransactionNpc;
    private TransactionManager transactionManager;
    private BookAssembler bookAssembler;
    private CardAssembler cardAssembler;

    void Start()
    {
        transactionManager = FindObjectOfType<TransactionManager>();
        bookAssembler = FindObjectOfType<BookAssembler>();
        cardAssembler = FindObjectOfType<CardAssembler>();
    }
    
    public void SetCurrentTransactionNpc(NpcController npc)
    {
        currentTransactionNpc = npc;
    }

    public void ProcessBook(BookParts book, bool isAccept)
    {
        if (currentTransactionNpc == null || book == null) return;

        var theNPC = currentTransactionNpc.npcData;
        var theBook = book.bookData;

        if (isAccept)
        {
            if (!theBook.isBorrowed)
                transactionManager.Borrowing(theNPC, System.DateTime.Now.ToString("yyyy-MM-dd"));
            else
                transactionManager.Returning(theNPC, theBook, System.DateTime.Now.ToString("yyyy-MM-dd"));
        }
        else
        {
            if (!theBook.isBorrowed)
            {
                theNPC.bookRequestId = 0; 
                theNPC.bookRequested = null;
            }
            Debug.Log($"Buku {theBook.bookId} di-Reject.");
        }

        bookAssembler.ClearBook(book.gameObject);
        ChangeStateLeaving();
    }
    
    public void ProcessCard(bool isAccept)
    {
        if (currentTransactionNpc == null) return;

        var theNPC = currentTransactionNpc.npcData;
        List<GameObject> booksToProcess = new List<GameObject>(bookAssembler.activeBooks);

        foreach (GameObject bookObj in booksToProcess)
        {
            if (bookObj == null) continue;
            BookParts bookComponent = bookObj.GetComponent<BookParts>();
            if (bookComponent == null) continue;

            var theBook = bookComponent.bookData;

            if (isAccept)
            {
                if (!theBook.isBorrowed)
                    transactionManager.Borrowing(theNPC, System.DateTime.Now.ToString("yyyy-MM-dd"));
                else
                    transactionManager.Returning(theNPC, theBook, System.DateTime.Now.ToString("yyyy-MM-dd"));
            }
            else
            {
                if (!theBook.isBorrowed)
                {
                    theNPC.bookRequestId = 0;
                    theNPC.bookRequested = null;
                }
            }
            bookAssembler.ClearBook(bookObj);
        }

        ChangeStateLeaving();
    }

    private void ChangeStateLeaving()
    {
        if (bookAssembler.activeBooks.Count == 0)
        {
            cardAssembler.ClearCard();
            currentTransactionNpc.currentState = NPCState.Leaving;
            currentTransactionNpc = null;
        }
    }
}