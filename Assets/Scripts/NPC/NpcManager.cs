using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcManager : MonoBehaviour
{
    [SerializeField] private GameObject npcTemplate;
    [SerializeField] private NPCDataInstance npcFactory;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Transform tablePoint;
    [SerializeField] private Transform exitPoint;
    [SerializeField] private float timeInterval = 5f;

    private GameObject currentNPC;
    private float timer = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentNPC == null)
        {
            timer += Time.deltaTime;
            if (timer >= timeInterval) 
            {
                SpawnNPC();
                timer = 0f;
            }
        }
    }

    private void SpawnNPC()
    {
        if (npcFactory.allNPCs.Count == 0)
        {
            Debug.LogWarning("No NPC data available to spawn.");
            return;
        }
        
        int randomIndex = Random.Range(0, npcFactory.allNPCs.Count);
        NPCDataTemplate npcData = npcFactory.allNPCs[randomIndex];

        currentNPC = Instantiate(npcTemplate, spawnPoint.position, Quaternion.identity);

        NpcController controller = currentNPC.GetComponent<NpcController>();
        NPCAssembler assembler = currentNPC.GetComponent<NPCAssembler>();
        
        controller.npcData = npcData;
        controller.tablePoint = tablePoint;
        controller.exitPoint = exitPoint;

        assembler.Assemble(npcData);

        controller.currentState = NPCState.WalkingToTable;

        Debug.Log("Spawned NPC with ID: " + npcData.npcId);
    }
}
