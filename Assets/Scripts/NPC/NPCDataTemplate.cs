using UnityEngine;

[CreateAssetMenu(fileName = "NPCData", menuName = "ScriptableObjects/NPCData")]
public class NPCDataTemplate : ScriptableObject
{
    [Header("NPC Identity")]
    public int npcID;
    public int npcFirstName;
    public int npcLastName;

    [Header("NPC Appearance")]
    public int hairIndex;
    public int outfitIndex;
    public int skinIndex;

    [Header("NPC Status")]
    public bool isBorrowing = false;
    public int borrowingTotal = 0;
    //public List<int> borrowedBookIDs = new List<int>();
}