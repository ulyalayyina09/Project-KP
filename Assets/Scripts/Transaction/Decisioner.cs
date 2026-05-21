using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decisioner : MonoBehaviour
{
    private NpcController currentTransactionNpc;
    private TransactionManager transactionManager;
    private BookParts selectedBook;
    
    private BookAssembler bookAssembler;

     void Start()
    {
        transactionManager = FindObjectOfType<TransactionManager>();
        bookAssembler = FindObjectOfType<BookAssembler>();
    }
    
    public void SetCurrentTransactionNpc(NpcController npc)
    {
        currentTransactionNpc = npc;
    }

    public void SelectBook(BookParts book)
    {
        selectedBook = book;
    }

    public void AcceptOnClicked()
    {
        if (currentTransactionNpc == null || selectedBook == null)
        {
            return;
        }

        var theNPC = currentTransactionNpc.npcData;
        var theBook = selectedBook.bookData;

        if (theBook.isBorrowed == false)
        {
            transactionManager.Borrowing(theNPC, System.DateTime.Now.ToString("yyyy-MM-dd"));
        }
        else
        {
            transactionManager.Returning(theNPC, theBook, System.DateTime.Now.ToString("yyyy-MM-dd"));
        }

        bookAssembler.ClearBook(selectedBook.gameObject);
        selectedBook = null;
        ChangeStateLeaving();
    }

    public void RejectOnClicked()
    {
        if (currentTransactionNpc == null || selectedBook == null)
        {
            return;
        }

        var theNPC = currentTransactionNpc.npcData;
        var theBook = selectedBook.bookData;

        if (theBook.isBorrowed == false)
        {
            theNPC.bookRequestId = 0; 
            Debug.Log("Borrowing request from NPC " + theNPC.npcId + " has been rejected.");
            
            bookAssembler.ClearBook(selectedBook.gameObject);
            selectedBook = null;
            ChangeStateLeaving();
        }
        else
        {
            Debug.Log("Unable to reject returning book request.");
        }
    }

    private void ChangeStateLeaving()
    {
        if (bookAssembler.activeBooks.Count == 0)
        {
            currentTransactionNpc.currentState = NPCState.Leaving;
            currentTransactionNpc = null;
        }
        else
        {
            return;
        }
    }
}
