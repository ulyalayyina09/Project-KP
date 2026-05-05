using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDataInstance : MonoBehaviour
{
    public int npcTotal = 5;
    public List<NPCDataTemplate> allNPCs = new List<NPCDataTemplate>();
    public NPCBank bank;

    public NPCAssembler NPCVisualTest; // Referensi ke assembler untuk testing visual
    
    // Start is called before the first frame update
    public void CreateEverything()
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
            newNPC.npcID = i + 1; //pkoknya mulai dri ONE wk
            newNPC.npcFirstNamE = Random.Range(0, bank.npcFirstNames.Length);
            newNPC.npcLastNamE = Random.Range(0, bank.npcLastNames.Length);
            newNPC.hairFrontIndeX = Random.Range(0, bank.hairFrontIndex.Length);
            newNPC.hairBackIndeX = newNPC.hairFrontIndeX;
            newNPC.outfitIndeX = Random.Range(0, bank.outfitIndex.Length);
            newNPC.skinIndeX = Random.Range(0, bank.skinIndex.Length);
            newNPC.faceIndeX = Random.Range(0, bank.faceIndex.Length);

            // Add the new NPC to the list
            allNPCs.Add(newNPC);
        }

        // TEST: Tampilkan NPC pertama (index 0) ke visualizer
        if(allNPCs.Count > 0)
        {
            NPCVisualTest.Assemble(allNPCs[1]);
        }
    }
}
