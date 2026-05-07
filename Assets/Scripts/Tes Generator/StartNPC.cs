using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartNPC : MonoBehaviour
{
    public NPCDataInstance npcDataInstance;
    
    // Start is called before the first frame update
    void Start()
    {
        npcDataInstance.GenerateNPCs();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
