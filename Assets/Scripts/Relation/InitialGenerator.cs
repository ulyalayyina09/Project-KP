using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialGenerator : MonoBehaviour
{
    public BookDataInstance bookFactory;
    public NPCDataInstance npcFactory;
    public Matchmaker matchmaker;
    public TransactionManager transactionManager;

    void Start()
    {
        bookFactory.GenerateBooks();
        npcFactory.GenerateNPCs();

        InitialBorrowing();
    }

    void InitialBorrowing()
    {
        int borrowingTarget = Mathf.FloorToInt(npcFactory.npcTotal * Random.Range(0.4f, 0.6f));
        int succeedCounter = 0;

        while (succeedCounter < borrowingTarget)
        {
            if (bookFactory.allBooks.FindAll(b => b.isAvailable).Count == 0)
            {
                Debug.LogWarning("No more available books for initial borrowing.");
                break;
            }
            
            int randomNpcIndex = Random.Range(0, npcFactory.allNPCs.Count);
            var selectedNPC = npcFactory.allNPCs[randomNpcIndex];

            if (selectedNPC.borrowingTotal < 2)
            {
                matchmaker.Matching(selectedNPC);

                var targetBook = bookFactory.allBooks.Find(b => b.bookId == selectedNPC.bookRequest);
                if (targetBook != null && targetBook.isAvailable)
                {
                    string borrowingDate = InitialBorrowingDate();
                    
                    transactionManager.Borrowing(selectedNPC, targetBook, borrowingDate);
                    succeedCounter++;
                }
            }
        }

    }

    string InitialBorrowingDate()
    {
        System.DateTime today = new System.DateTime(2025, 9, 14);
        int backDays = Random.Range(1, 30);
        return today.AddDays(-backDays).ToString("yyyy-MM-dd");
    }
}
