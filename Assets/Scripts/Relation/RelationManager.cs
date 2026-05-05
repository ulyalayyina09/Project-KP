using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelationManager : MonoBehaviour
{
    public BookDataInstance bookFactory;
    public NPCDataInstance npcFactory;

    void Start()
    {
        bookFactory.CreateEverything();
        npcFactory.CreateEverything();

        GenerateRelations();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void GenerateRelations()
    {
        var bookList = bookFactory.allBooks;
        var npcList = npcFactory.allNPCs;

        float percentage = Random.Range(0.3f, 0.6f);
        int borrowedCount = Mathf.FloorToInt(npcList.Count * percentage);

        int succeedCount = 0;
        while (succeedCount < borrowedCount)
        {
            int randomNPCIndex = Random.Range(0, npcList.Count);
            var selectedNPC = npcList[randomNPCIndex];

            if (selectedNPC.borrowingTotal < 2)
            {
                var availableBooks = bookList.FindAll(b => b.isAvailable);

                if (availableBooks.Count > 0)
                {
                    int randomBookIndex = Random.Range(0, availableBooks.Count);
                    var selectedBook = availableBooks[randomBookIndex];

                    selectedNPC.borrowedBookIDs.Add(selectedBook.bookId);
                    selectedNPC.isBorrowing = true;
                    selectedNPC.borrowingTotal += 1;

                    selectedBook.isBorrowed = true;
                    selectedBook.isAvailable = false;
                    
                    succeedCount++;

                    Debug.Log("NPC " + selectedNPC.npcID + " borrowed book " + selectedBook.bookId);
                }
                
                else
                {
                    Debug.LogWarning("No more available books");
                    break;
                }
            }
        }
    }
}
