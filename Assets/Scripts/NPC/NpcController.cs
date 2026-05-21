using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NPCState
{
    Spawning,
    WalkingToTable,
    Idle,
    Leaving
}

public class NpcController : MonoBehaviour
{
    [HideInInspector] public NPCState currentState;
    [HideInInspector] public NPCDataTemplate npcData;
    [HideInInspector] public Transform tablePoint;
    [HideInInspector] public Transform exitPoint;
    private Matchmaker matchmaker;
    private BookAssembler bookAssembler;
    [SerializeField] private float walkSpeed = 2f;

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case NPCState.WalkingToTable:
                MoveTo(tablePoint.position);
                if (Vector3.Distance(transform.position, tablePoint.position) < 0.1f)
                {   
                    currentState = NPCState.Idle;

                    Decisioner decisioner = FindObjectOfType<Decisioner>();
                    decisioner.SetCurrentTransactionNpc(this);

                    //nentuin jenis transaksi
                    int transactionType = Random.Range(1, 3);
                    if (transactionType == 1 && npcData.borrowingTotal > 0) //return
                    {
                        bookAssembler = FindObjectOfType<BookAssembler>();
                        BookDataInstance bookDatabase = FindObjectOfType<BookDataInstance>();

                        if (bookDatabase != null)
                        {
                            foreach (int borrowedId in npcData.borrowedBookIds)
                            {
                                BookDataTemplate matchingBook = bookDatabase.allBooks.Find(buku => buku.bookId == borrowedId);
                                if (matchingBook != null)
                                {
                                    bookAssembler.AssembleBook(matchingBook);
                                }
                            }
                        }
                        Debug.Log("NPC " + npcData.npcId + " is requesting to return " + npcData.borrowingTotal + " book(s).");
                    }
                    else
                    {
                        matchmaker = FindObjectOfType<Matchmaker>();
                        matchmaker.Matching(npcData);

                        bookAssembler = FindObjectOfType<BookAssembler>();
                        bookAssembler.AssembleBook(npcData.bookRequested);

                        Debug.Log("NPC " + npcData.npcId + " is requesting to borrow " + npcData.bookRequestId + " (" + npcData.bookRequested.bookTitle + ")");
                    }
                }
                break;
            
            case NPCState.Idle:
                // NPC is idle at the table, waiting for interaction
                break;

            case NPCState.Leaving:
                if (exitPoint != null)
                {
                    MoveTo(exitPoint.position);

                    if (Vector3.Distance(transform.position, exitPoint.position) < 0.1f)
                    {
                        Debug.Log("NPC " + npcData.npcId + " has left the library.");
                        Destroy(gameObject); // NPC leaves the scene
                    }
                }
                break; 
        }
    }

    private void MoveTo(Vector3 targetPosition)
    {
        Vector3 direction = (targetPosition - transform.position).normalized;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, walkSpeed * Time.deltaTime);
    }
}
