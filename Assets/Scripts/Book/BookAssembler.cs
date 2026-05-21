using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BookAssembler : MonoBehaviour
{
    [SerializeField] private BookBank bank; // Referensi gudang
    [SerializeField] private GameObject bookPrefab; // Prefab visual buku
    [SerializeField] private Transform spawnPoint; // Titik spawn buku
    [SerializeField] private float bookSpacing = 0.3f;
    public List<GameObject> activeBooks { get; private set; } = new List<GameObject>();

    public void AssembleBook(BookDataTemplate data)
    {
        if (activeBooks.Count >= 3)
        {
            return;
        }
        
        float currentOffset = activeBooks.Count * bookSpacing;
        Vector3 spawnPosition = spawnPoint.position + new Vector3(currentOffset, 0, 0);
        
        GameObject theBook = Instantiate(bookPrefab, spawnPosition, Quaternion.identity);
        theBook.transform.SetParent(this.transform);
        BookParts parts = theBook.GetComponent<BookParts>();

        if (parts != null)
        {
            parts.cover.sprite = bank.bookCoverSprite;
            parts.label.sprite = bank.bookLabelSprite;
            parts.paper.sprite = bank.bookPaperSprite;
            parts.cover.color = data.bookColor;
            parts.bookData = data;
        }
        
        activeBooks.Add(theBook);
        Debug.Log("Book visual created for ID: " + data.bookId + " : " + data.bookTitle);
    }

    public void ClearBook(GameObject bookObject)
    {
        if (activeBooks.Contains(bookObject))
        {
            activeBooks.Remove(bookObject);
            Destroy(bookObject);
        }
    }
    
    
    //[Header("(IGNORE): Target Renderers")]
    //public SpriteRenderer coverRenderer;
    //public SpriteRenderer labelRenderer;
    //public SpriteRenderer paperRenderer;
    //private void AssembleBook1(BookDataTemplate data)
    //{
    //    if (bank == null) Debug.LogError("Book Bank reference is missing in BookAssembler.");
    //    if (coverRenderer == null) Debug.LogError("Cover Renderer reference is missing in BookAssembler.");
    //    if (labelRenderer == null) Debug.LogError("Label Renderer reference is missing in BookAssembler.");
    //    if (paperRenderer == null) Debug.LogError("Paper Renderer reference is missing in BookAssembler.");

    //    coverRenderer.sprite = bank.bookCoverSprite;
    //    labelRenderer.sprite = bank.bookLabelSprite;
    //    paperRenderer.sprite = bank.bookPaperSprite;

    //    coverRenderer.color = data.bookColor; 
        
    //    Debug.Log("Book visual created for ID: " + data.bookId);
    //}
}