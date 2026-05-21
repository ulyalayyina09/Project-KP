using UnityEngine;

public class BookAssemblerDiBuku : MonoBehaviour
{
    public BookBank bank; // Referensi ke gudang
    public GameObject bookPrefab; // Prefab untuk visual buku
    public Transform spawnPoint; // Titik spawn untuk buku

    public void AssembleBook(BookDataTemplate data)
    {
        GameObject theBook = Instantiate(bookPrefab, spawnPoint.position, Quaternion.identity);

        BookParts parts = theBook.GetComponent<BookParts>();
        if (parts != null)
        {
            parts.cover.sprite = bank.bookCoverSprite;
            parts.label.sprite = bank.bookLabelSprite;
            parts.paper.sprite = bank.bookPaperSprite;

            parts.cover.color = data.bookColor; 
        }
        else
        {
            Debug.LogError("Book prefab is missing the BookParts component.");
        }
        theBook.transform.SetParent(this.transform); // Set parent ke BookAssembler untuk organisasi
        Debug.Log("Book visual created for ID: " + data.bookId + " : " + data.bookTitle);
    }
    
    
    [Header("(IGNORE) Target Renderers")]
    public SpriteRenderer coverRenderer;
    public SpriteRenderer labelRenderer;
    public SpriteRenderer paperRenderer;
    private void AssembleBook1(BookDataTemplate data)
    {
        if (bank == null) Debug.LogError("Book Bank reference is missing in BookAssembler.");
        if (coverRenderer == null) Debug.LogError("Cover Renderer reference is missing in BookAssembler.");
        if (labelRenderer == null) Debug.LogError("Label Renderer reference is missing in BookAssembler.");
        if (paperRenderer == null) Debug.LogError("Paper Renderer reference is missing in BookAssembler.");

        coverRenderer.sprite = bank.bookCoverSprite;
        labelRenderer.sprite = bank.bookLabelSprite;
        paperRenderer.sprite = bank.bookPaperSprite;

        coverRenderer.color = data.bookColor; 
        
        Debug.Log("Book visual created for ID: " + data.bookId);
    }
}