using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HistoryTable : MonoBehaviour
{
    [SerializeField] private GameObject rowPrefab;
    [SerializeField] private Transform tableContentParent;
    
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

        RecordHistory dbComponent = FindObjectOfType<RecordHistory>();

        if (dbComponent == null)
        {
            Debug.LogError("RecordHistory is missing");
            return;
        }

        List<LoanEntry> liveRecords = dbComponent.allRecords;

        for (int i = 0; i < liveRecords.Count; i++)
        {
            LoanEntry currentRecord = liveRecords[i];
            GameObject newRow = Instantiate(rowPrefab, tableContentParent);
            HistoryRowContainer container = newRow.GetComponent<HistoryRowContainer>();

            if (container != null)
            {
                container.txtNo.text = (i + 1).ToString();
                container.txtID.text = currentRecord.loanId;
                container.txtName.text = currentRecord.npcName;
                container.txtTitle.text = currentRecord.bookTitle;
                if (currentRecord.status == LoanStatus.Borrowing)
                {
                    container.txtStatus.text = "Borrowing";
                }
                else
                {
                    container.txtStatus.text = "Returned";
                }
            }
        }
    }
}
