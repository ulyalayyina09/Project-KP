using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BookInspectPopUp : MonoBehaviour
{
    [SerializeField] private Image Base;
    [SerializeField] private TextMeshProUGUI bookId;
    [SerializeField] private TextMeshProUGUI bookTitle;

    public void OpenPopUp(BookDataTemplate bookData)
    {
        bookId.text = "#" + bookData.bookId.ToString("D2") + " - " + bookData.copyId.ToString("D2");
        bookTitle.text = bookData.bookTitle;
        Base.color = bookData.bookColor;

        gameObject.SetActive(true);
    }
}
