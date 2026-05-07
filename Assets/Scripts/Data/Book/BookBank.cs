using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewBookBank", menuName = "Library/Book Bank")]
public class BookBank : ScriptableObject
{
    public string[] Title;
    [TextArea]
    public string[] Description;

    public Sprite bookCoverSprite;
    public Sprite bookLabelSprite;
    public Sprite bookPaperSprite;
}
