using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewBookData", menuName = "ScriptableObjects/BookData")]
public class BookDataTemplate : ScriptableObject
{
    [Header("Book base")]
    public int bookID;
    public int bookTitlE;

    [Header("Book Details")]
    public Color bookColoR;
    public int bookDescriptioN;

    [Header("Book Status")]
    public bool isBorrowed = false;
    public bool isDamaged = false;
    public bool isAvailable = true;
}
