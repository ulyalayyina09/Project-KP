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
        // Pastikan renderernya tidak kosong
        if (coverRenderer == null || bank == null) {
            Debug.LogError("Ada yang belum ditarik ke Inspector nih!");
            return;
        }

        // Ambil gambar dari Bank, lalu tempel
        coverRenderer.sprite = bank.bookCoverSprite;
        labelRenderer.sprite = bank.bookLabelSprite;
        paperRenderer.sprite = bank.bookPaperSprite;

        // Ambil warna dari Data, lalu tempel
        coverRenderer.color = data.bookColoR; 
        
        // Pastikan Alpha/Opacity-nya 1 (tidak transparan)
        Debug.Log("Mencoba menampilkan buku: " + data.bookID);
    }
}