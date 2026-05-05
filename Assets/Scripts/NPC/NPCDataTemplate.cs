using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NPCData", menuName = "ScriptableObjects/NPCData")]
public class NPCDataTemplate : ScriptableObject
{
    [Header("NPC Identity")]
    public int npcID;
    public int npcFirstNamE;
    public int npcLastNamE;

    [Header("NPC Appearance")]
    public int hairFrontIndeX;
    public int hairBackIndeX;
    public int outfitIndeX;
    public int skinIndeX;
    public int faceIndeX;

    [Header("NPC Status")]
    public bool isBorrowing = false;
    public int borrowingTotal = 0;
    public List<int> borrowedBookIDs = new List<int>();
}