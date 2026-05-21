using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matchmaker : MonoBehaviour
{
    [SerializeField] private BookDataInstance bookFactory;

    public void Matching(NPCDataTemplate npc)
    {
        //if (npc.borrowingTotal >= 2)
        //{
        //    Debug.Log("NPC " + npc.npcId + " has already borrowed 2 books.");
        //    return;
        //}

        List<BookDataTemplate> availableBooks = bookFactory.allBooks.FindAll(b => b.isAvailable);

        if (availableBooks.Count > 0)
        {
            int randomBookIndex = Random.Range(0, availableBooks.Count);
            BookDataTemplate selectedBook = availableBooks[randomBookIndex];

            npc.bookRequestId = selectedBook.bookId;
            npc.bookRequested = selectedBook;
        }
        else
        {
            Debug.LogWarning("No available books for NPC " + npc.npcId);
        }
    }
}
