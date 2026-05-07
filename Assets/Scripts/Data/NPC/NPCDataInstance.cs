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
            newNPC.npcId = i + 1; //pkoknya mulai dri ONE wk
            newNPC.npcFirstName = Random.Range(0, bank.npcFirstNames.Length);
            newNPC.npcLastName = Random.Range(0, bank.npcLastNames.Length);
            newNPC.hairFrontIndex = Random.Range(0, bank.hairFront.Length);
            newNPC.hairBackIndex = newNPC.hairFrontIndex;
            newNPC.outfitIndex = Random.Range(0, bank.outfit.Length);
            newNPC.skinIndex = Random.Range(0, bank.skin.Length);
            newNPC.faceIndex = Random.Range(0, bank.face.Length);

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
