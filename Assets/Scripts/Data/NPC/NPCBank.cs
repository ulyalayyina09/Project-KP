using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewNPCBank", menuName = "Library/NPC Bank")]  
public class NPCBank : ScriptableObject
{
    public string[] npcFirstNames;
    public string[] npcLastNames;

    public Sprite[] hairFront;
    public Sprite[] hairBack;
    public Sprite[] outfit;
    public Sprite[] face;
    public Sprite[] skin;
}
