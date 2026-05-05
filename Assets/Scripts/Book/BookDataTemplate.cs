using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewBookData", menuName = "ScriptableObjects/BookData")]
public class BookDataTemplate : ScriptableObject
{
    [Header("Book base")]
    public int bookId;
    public int bookTitle;

    [Header("Book Details")]
    public Color bookColor;
    public int bookDescription;

    [Header("Book Status")]
    public bool isBorrowed = false;
    public bool isDamaged = false;
    public bool isAvailable = true;

    [Header("Copy Info")]
    public int copyId;
    public int totalCopies;
}
