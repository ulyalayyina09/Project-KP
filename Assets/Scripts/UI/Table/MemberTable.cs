using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemberTable : MonoBehaviour
{
    [SerializeField] private GameObject rowPrefab;
    [SerializeField] private Transform tableContentParent;
    [SerializeField] private MemberDetailPanel detailPanel;
    private List<NPCDataTemplate> liveNpcList;
    
    private void OnEnable()
    {
        RefreshTable();
    }

    public void RefreshTable()
    {
        foreach (Transform child in tableContentParent)
        {
            Destroy(child.gameObject);
        }

        NPCDataInstance dbComponent = FindObjectOfType<NPCDataInstance>();

        if (dbComponent == null)
        {
            Debug.LogError("NPCDataInstance is missing");
            return;
        }

        liveNpcList = new List<NPCDataTemplate>(dbComponent.allNPCs);
        liveNpcList.Sort((npcA, npcB) => npcA.npcId.CompareTo(npcB.npcId));

        for (int i = 0; i < liveNpcList.Count; i++)
        {
            NPCDataTemplate currentNpc = liveNpcList[i];
            GameObject newRow = Instantiate(rowPrefab, tableContentParent);
            NpcRowContainer container = newRow.GetComponent<NpcRowContainer>();

            if (container != null)
            {
                container.txtNo.text = (i + 1).ToString();
                container.txtID.text = currentNpc.npcId.ToString("D4");
                container.txtName.text = currentNpc.npcFirstName + " " + currentNpc.npcLastName;
                if (currentNpc.isBorrowing == false)
                {
                    container.txtStatus.text = "Active";
                }
                else
                {
                    container.txtStatus.text = "Borrowing";
                }

                if (detailPanel == null)
                {
                    detailPanel = FindObjectOfType<MemberDetailPanel>(true);
                }

                container.SetupRow(currentNpc, detailPanel);
            }
        }
    }
}
