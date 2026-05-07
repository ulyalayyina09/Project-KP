using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matchmaker : MonoBehaviour
{
    public BookDataInstance bookFactory;
    public NPCDataInstance npcFactory;

    public void Matching(NPCDataTemplate npc)
    {
        if (npc.borrowingTotal >= 2)
        {
            Debug.Log("NPC " + npc.npcId + " has already borrowed 2 books.");
            return;
        }

        List<BookDataTemplate> availableBooks = bookFactory.allBooks.FindAll(b => b.isAvailable);

        if (availableBooks.Count > 0)
        {
            int randomBookIndex = Random.Range(0, availableBooks.Count);
            BookDataTemplate selectedBook = availableBooks[randomBookIndex];

            npc.bookRequest = selectedBook.bookId;

            Debug.Log("NPC " + npc.npcId + " is requesting book " + selectedBook.bookId);
        }
        else
        {
            Debug.LogWarning("No available books for NPC " + npc.npcId);
        }
    }
}
