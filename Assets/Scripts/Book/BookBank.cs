using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookBank : MonoBehaviour
{
    public string[] Title;
    [TextArea]
    public string[] Description;

    public Sprite bookCoverSprite;
    public Sprite bookLabelSprite;
    public Sprite bookPaperSprite;
}
