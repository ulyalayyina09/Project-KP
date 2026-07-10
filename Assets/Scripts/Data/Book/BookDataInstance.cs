using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookDataInstance : MonoBehaviour
{
    [SerializeField] private int bookVariantTotal = 10;
    [SerializeField] private int totalLibBooks = 0;
    [SerializeField] private int maxCopyPerBook = 5;
    public List<BookDataTemplate> allBooks = new List<BookDataTemplate>();
    [SerializeField] private BookBank bank;

    public void GenerateBooks()
    {
        int globalIDCounter = 1; 
        allBooks.Clear();

        List<int> availableTitle = new List<int>();
        for (int k = 0; k < bank.Title.Length; k++)
        {
            availableTitle.Add(k);
        }

        int actualVariants = Mathf.Min(bookVariantTotal, bank.Title.Length);
        for (int i = 0; i < actualVariants; i++)
        {
            int randomListIndex = Random.Range(0, availableTitle.Count);
            int selectedTitleIndex = availableTitle[randomListIndex];

            availableTitle.RemoveAt(randomListIndex);
            
            Color selectedColor = new Color(Random.value, Random.value, Random.value);

            int randomCopyCount = Random.Range(1, (maxCopyPerBook + 1));

            for (int j = 0; j < randomCopyCount; j++)
            {
                BookDataTemplate newBook = ScriptableObject.CreateInstance<BookDataTemplate>();

                newBook.bookId = globalIDCounter;
                newBook.bookTitle = bank.Title[selectedTitleIndex];
                newBook.bookColor = selectedColor;
                newBook.bookDescription = bank.Description[selectedTitleIndex];
                newBook.copyId = j + 1;
                newBook.totalCopies = randomCopyCount;

                allBooks.Add(newBook);
            }

            globalIDCounter++;
        }

        totalLibBooks = allBooks.Count;

        // TEST: Tampilkan buku pertama (index 0) ke console
        //if(allBooks.Count > 0)       
        //{
        //    bookVisualTest.AssembleBook(allBooks[0]);
        //    Debug.Log("Buku pertama: " + bank.Title[allBooks[0].bookTitle] + " dengan warna: " + allBooks[0].bookColor);
        //}
    }
}
