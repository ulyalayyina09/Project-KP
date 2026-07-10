using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CardAssembler : MonoBehaviour
{
    [SerializeField] private GameObject cardPrefab; // Prefab visual 
    [SerializeField] private Transform spawnPoint; // Titik spawn 
    private GameObject activeCard;

    public void AssembleCard(NPCDataTemplate data)
    {   
        if (activeCard != null)
        {
            Destroy(activeCard);
        }
        
        GameObject theCard = Instantiate(cardPrefab, spawnPoint.position, Quaternion.identity);
        theCard.transform.SetParent(this.transform);

        activeCard = theCard;
        CardParts parts = theCard.GetComponent<CardParts>();

        if (parts != null)
        {
            parts.npcData = data;
        }
    }

    public void ClearCard()
    {
        if (activeCard != null)
        {
            Destroy(activeCard);
            activeCard = null;
        }
    }
}