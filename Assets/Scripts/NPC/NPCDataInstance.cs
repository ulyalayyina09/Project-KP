using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDataInstance : MonoBehaviour
{
    public int npcTotal = 5;
    public List<NPCDataTemplate> allNPCs = new List<NPCDataTemplate>();
    
    // Start is called before the first frame update
    void Start()
    {
        GenerateNPCs();
    }

    void GenerateNPCs()
    {
        for (int i = 0; i < npcTotal; i++)
        {
            // Create new instance of NPCDataTemplate
            NPCDataTemplate newNPC = ScriptableObject.CreateInstance<NPCDataTemplate>();

            // Assign random values to the new NPC
            //JANLUP NAMBAHIN REFERENCE VARIABEL BANK BUAT REPLACE "template."
            newNPC.npcID = i + 1; //pkoknya mulai dri ONE wk
            newNPC.npcFirstName = Random.Range(0, template.npcFirstNames.Length);
            newNPC.npcLastName = Random.Range(0, template.npcLastNames.Length);
            newNPC.hairIndex = Random.Range(0, template.hairIndex.Length);
            newNPC.outfitIndex = Random.Range(0, template.outfitIndex.Length);
            newNPC.skinIndex = Random.Range(0, template.skinIndex.Length);

            // Add the new NPC to the list
            allNPCs.Add(newNPC);
        }
    }
}
