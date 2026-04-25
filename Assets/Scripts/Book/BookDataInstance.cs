using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookDataInstance : MonoBehaviour
{
    public int bookTotal = 10;
    public List<BookDataTemplate> allBooks = new List<BookDataTemplate>();
    
    // Start is called before the first frame update
    void Start()
    {
        GenerateBooks();
    }

    void GenerateBooks()
    {
        for (int i = 0; i < bookTotal; i++)
        {
            // Create new instance of BookDataTemplate
            BookDataTemplate newBook = ScriptableObject.CreateInstance<BookDataTemplate>();

            // Assign random values to the new Book
            newBook.bookID = i + 1; // Unique ID starting from 1
            newBook.bookTitle = Random.Range(0, bank.bookTitles.Length);
            newBook.bookColor = new Color(Random.value, Random.value, Random.value); // Random color
            newBook.designIndex = Random.Range(0, bank.designs.Length);
            newBook.bookDescription = newBook.bookTitle; // Assuming description is the same as title for now

            // Add the Book to the list
            allBooks.Add(newBook);
            
        }
    }
}
