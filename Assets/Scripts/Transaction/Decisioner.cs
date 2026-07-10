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

<<<<<<< Updated upstream
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
=======
    public void AcceptButton()
    {
        ProcessSession(true);
    }

    public void RejectButton()
    {
        ProcessSession(false);
    }

    private void ProcessSession(bool isAccept)
    {
        if (currentTransactionNpc == null) return;

        var theNPC = currentTransactionNpc.npcData;

        Evaluator evaluator = FindObjectOfType<Evaluator>();
        if (evaluator != null)
        {
            evaluator.EvaluateExpCard(theNPC, isAccept);
        }

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
            cardAssembler.ClearCard();
        }

        // 3. Bersihkan kartu dan usir NPC   cardAssembler.ClearCard();
        currentTransactionNpc.currentState = NPCState.Leaving;
        currentTransactionNpc = null;
>>>>>>> Stashed changes
    }
}
