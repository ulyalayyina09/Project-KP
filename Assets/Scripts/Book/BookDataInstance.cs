using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookDataInstance : MonoBehaviour
{
    public int bookTotal = 10;
    public List<BookDataTemplate> allBooks = new List<BookDataTemplate>();
    public BookBank bank;

    public BookAssembler bookVisualTest; // Referensi ke assembler untuk testing visual
    
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
            newBook.bookTitlE = Random.Range(0, bank.bookTitle.Length);
            newBook.bookColoR = new Color(Random.value, Random.value, Random.value); // Random color
            newBook.bookDescriptioN = newBook.bookTitlE; 

            // Add the Book to the list
            allBooks.Add(newBook);
            
        }

        // TEST: Tampilkan buku pertama (index 0) ke console
        if(allBooks.Count > 0)       
        {
            bookVisualTest.AssembleBook(allBooks[0]);
            Debug.Log("Buku pertama: " + bank.bookTitle[allBooks[0].bookTitlE] + " dengan warna: " + allBooks[0].bookColoR);
        }
    }
}
