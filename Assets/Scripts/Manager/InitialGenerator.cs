using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialGenerator : MonoBehaviour
{
    [SerializeField] private BookDataInstance bookFactory;
    [SerializeField] private NPCDataInstance npcFactory;
    [SerializeField] private Matchmaker matchmaker;
    [SerializeField] private TransactionManager transactionManager;

    void Awake()
    {
        if (bookFactory == null)
            Debug.LogError("BookDataInstance is not assigned in InitialGenerator.");
        if (npcFactory == null)
            Debug.LogError("NPCDataInstance is not assigned in InitialGenerator.");
        if (matchmaker == null)
            Debug.LogError("Matchmaker is not assigned in InitialGenerator.");
        if (transactionManager == null)
            Debug.LogError("TransactionManager is not assigned in InitialGenerator.");
        
        bookFactory.GenerateBooks();
        npcFactory.GenerateNPCs();
    }
    
    void Start()
    {
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

                var targetBook = bookFactory.allBooks.Find(b => b.bookId == selectedNPC.bookRequestId);
                if (targetBook != null && targetBook.isAvailable)
                {
                    string borrowingDate = InitialBorrowingDate();
                    
                    transactionManager.Borrowing(selectedNPC, borrowingDate);
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
