using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookBank : MonoBehaviour
{
    public string[] bookTitle;
    [TextArea]
    public string[] bookDescription;

    public Sprite bookCoverSprite;
    public Sprite bookLabelSprite;
    public Sprite bookPaperSprite;
}
