using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDataInstance : MonoBehaviour
{
    public int npcTotal = 5;
    public List<NPCDataTemplate> allNPCs = new List<NPCDataTemplate>();
    public NPCBank template;

    public NPCAssembler NPCVisualTest; // Referensi ke assembler untuk testing visual
    
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
            newNPC.npcFirstNamE = Random.Range(0, template.npcFirstNames.Length);
            newNPC.npcLastNamE = Random.Range(0, template.npcLastNames.Length);
            newNPC.hairFrontIndeX = Random.Range(0, template.hairFrontIndex.Length);
            newNPC.hairBackIndeX = newNPC.hairFrontIndeX;
            newNPC.outfitIndeX = Random.Range(0, template.outfitIndex.Length);
            newNPC.skinIndeX = Random.Range(0, template.skinIndex.Length);
            newNPC.faceIndeX = Random.Range(0, template.faceIndex.Length);

            // Add the new NPC to the list
            allNPCs.Add(newNPC);
        }

        // TEST: Tampilkan NPC pertama (index 0) ke visualizer
        if(allNPCs.Count > 0)
        {
            NPCVisualTest.Assemble(allNPCs[0]);
        }
    }
}
