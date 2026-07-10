using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardParts : MonoBehaviour
{
    public SpriteRenderer body;
    public SpriteRenderer information;
    public GameObject selectedOutline;
    public GameObject actionButton;

    [HideInInspector] public NPCDataTemplate npcData;
}
