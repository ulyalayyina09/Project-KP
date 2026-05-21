using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewBookData", menuName = "ScriptableObjects/BookData")]
public class BookDataTemplate : ScriptableObject
{
    [Header("Book base")]
    public int bookId;
    public string bookTitle;

    [Header("Book Details")]
    public Color bookColor;
    public string bookDescription;

    [Header("Copy Info")]
    public int copyId;
    public int totalCopies;

    [Header("Book Status")]
    public bool isBorrowed = false;
    public bool isDamaged = false;
    public bool isAvailable = true;
    public string currentLoanId;
}
