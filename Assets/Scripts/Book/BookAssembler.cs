using UnityEngine;

public class BookAssembler : MonoBehaviour
{
    public BookBank bank; // Referensi ke gudang

    [Header("Target Renderers")]
    public SpriteRenderer coverRenderer;
    public SpriteRenderer labelRenderer;
    public SpriteRenderer paperRenderer;

    public void AssembleBook(BookDataTemplate data)
    {
        if (coverRenderer == null || bank == null) {
            Debug.LogError("Something is missing: ");
            return;
        }

        coverRenderer.sprite = bank.bookCoverSprite;
        labelRenderer.sprite = bank.bookLabelSprite;
        paperRenderer.sprite = bank.bookPaperSprite;

        coverRenderer.color = data.bookColor; 
        
        Debug.Log("ID Buku: " + data.bookId);
    }
}