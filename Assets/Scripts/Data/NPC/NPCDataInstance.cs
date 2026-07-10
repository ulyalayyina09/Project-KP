using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDataInstance : MonoBehaviour
{
    public int npcTotal = 5;
    public List<NPCDataTemplate> allNPCs = new List<NPCDataTemplate>();
    [SerializeField] private NPCBank bank;

    public void GenerateNPCs()
    {
        for (int i = 0; i < npcTotal; i++)
        {
            // Create new instance of NPCDataTemplate
            NPCDataTemplate newNPC = ScriptableObject.CreateInstance<NPCDataTemplate>();

            // Assign random values to the new NPC
            newNPC.npcId = i + 1; //pkoknya mulai dri ONE wk

            int randomFirstNameIndex = Random.Range(0, bank.npcFirstNames.Length);
            int randomLastNameIndex = Random.Range(0, bank.npcLastNames.Length);
            int randomAddressIndex = Random.Range(0, bank.npcAddresses.Length);
            newNPC.npcFirstName = bank.npcFirstNames[randomFirstNameIndex];
            newNPC.npcLastName = bank.npcLastNames[randomLastNameIndex];
            newNPC.npcAddress = bank.npcAddresses[randomAddressIndex];

            newNPC.hairFrontIndex = Random.Range(0, bank.hairFront.Length);
            newNPC.hairBackIndex = newNPC.hairFrontIndex;
            newNPC.outfitIndex = Random.Range(0, bank.outfit.Length);
            newNPC.skinIndex = Random.Range(0, bank.skin.Length);
            newNPC.faceIndex = Random.Range(0, bank.face.Length);

            int birthMonth = Random.Range(1, 13);
            int birthYear = Random.Range(1970, 2010);
            int maxBirthDay = System.DateTime.DaysInMonth(birthYear, birthMonth);
            int birthDay = Random.Range(1, maxBirthDay + 1);
            newNPC.npcBirthDate = new System.DateTime(birthYear, birthMonth, birthDay);

            int expMonth = Random.Range(1, 13);
            int expYear = 2025;
            int maxExpDay = System.DateTime.DaysInMonth(expYear, expMonth);
            int expDay = Random.Range(1, maxExpDay + 1);
            newNPC.cardExpDate = new System.DateTime(expYear, expMonth, expDay);

            // Add the new NPC to the list
            allNPCs.Add(newNPC);
        }

        // TEST: Tampilkan NPC pertama (index 0) ke visualizer
        //if(allNPCs.Count > 0)
        //{
        //    NPCVisualTest.Assemble(allNPCs[0]);
        //}
    }
}
