using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NPCData", menuName = "ScriptableObjects/NPCData")]
public class NPCDataTemplate : ScriptableObject
{
    [Header("NPC Identity")]
    public int npcId;
    public int npcFirstName;
    public int npcLastName;

    [Header("NPC Appearance")]
    public int hairFrontIndex;
    public int hairBackIndex;
    public int outfitIndex;
    public int skinIndex;
    public int faceIndex;

    [Header("NPC Status")]
    public bool isBorrowing = false;
    public int borrowingTotal = 0;
    public List<int> borrowedBookIds = new List<int>();
}