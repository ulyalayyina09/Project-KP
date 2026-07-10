using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookTable : MonoBehaviour
{
    [SerializeField] private GameObject rowPrefab;
    [SerializeField] private Transform tableContentParent;
    private List<BookDataTemplate> liveBookList;
    
    private void OnEnable()
    {
        RefreshTable();
    }

    public void RefreshTable()
    {
        foreach (Transform child in tableContentParent)
        {
            Destroy(child.gameObject);
        }

        BookDataInstance dbComponent = FindObjectOfType<BookDataInstance>();

        if (dbComponent == null)
        {
            Debug.LogError("BookDataInstance is missing");
            return;
        }

        liveBookList = new List<BookDataTemplate>(dbComponent.allBooks);
        liveBookList.Sort((bookA, bookB) => bookA.bookId.CompareTo(bookB.bookId));

        for (int i = 0; i < liveBookList.Count; i++)
        {
            BookDataTemplate currentBook = liveBookList[i];
            GameObject newRow = Instantiate(rowPrefab, tableContentParent);
            BookRowContainer container = newRow.GetComponent<BookRowContainer>();

            if (container != null)
            {
                container.txtNo.text = (i + 1).ToString();
                container.txtID.text = currentBook.bookId.ToString("D2") + " - " + currentBook.copyId.ToString("D2");
                container.txtTitle.text = currentBook.bookTitle;
                if (currentBook.isAvailable == true)
                {
                    container.txtStatus.text = "Available";
                }
                else
                {
                    container.txtStatus.text = "Unavailable";
                }
            }
        }
    }
}
