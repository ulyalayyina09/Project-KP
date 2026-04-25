using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewBookData", menuName = "ScriptableObjects/BookData")]
public class BookDataTemplate : ScriptableObject
{
    [Header("Book base")]
    public int bookID;
    public int bookTitle;

    [Header("Book Details")]
    public Color bookColor;
    public int designIndex;
    public int bookDescription;

    [Header("Book Status")]
    public bool isBorrowed = false;
    public bool isDamaged = false;
    public bool isAvailable = true;
}
