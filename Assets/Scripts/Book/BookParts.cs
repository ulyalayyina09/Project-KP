using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookParts : MonoBehaviour
{
    public SpriteRenderer cover;
    public SpriteRenderer label;
    public SpriteRenderer paper;

    public GameObject selectedOutline;
    public GameObject actionButton;

    [HideInInspector] public BookDataTemplate bookData;
}
