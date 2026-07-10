using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MemberDetailPanel : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private Image imgProfile;
    [SerializeField] private TextMeshProUGUI txtId;
    [SerializeField] private TextMeshProUGUI txtName;
    [SerializeField] private TextMeshProUGUI txtBirth;
    [SerializeField] private TextMeshProUGUI txtAddress;
    [SerializeField] private TextMeshProUGUI txtExpDate;

    [SerializeField] private GameObject trnscMembPrefab; 
    [SerializeField] private Transform transactionTableContentParent;

    
    private NPCDataTemplate currentNpc;
    public void OpenDetail(NPCDataTemplate npc)
    {
        if (npc == null)
        {
            Debug.LogError("NPC data is null. Cannot open detail panel.");
            return;
        }

        currentNpc = npc;

        txtId.text = "ID MEMBER : #" + npc.npcId.ToString("D4");
        txtName.text = npc.npcFirstName + " " + npc.npcLastName;
        txtBirth.text = npc.npcBirthDate.ToString("dd MMMM yyyy");
        txtAddress.text = npc.npcAddress;
        txtExpDate.text = npc.cardExpDate.ToString("dd/MM/yyyy");

        foreach (Transform child in transactionTableContentParent)
        {
            Destroy(child.gameObject);
        }

        RecordHistory history = FindObjectOfType<RecordHistory>();
        if (history != null)
        {
            // Filter: Hanya ambil transaksi milik NPC ini saja
            List<LoanEntry> npcRecords = history.allRecords.FindAll(r => r.npcId == npc.npcId);

            // Urutkan: Sesuai maumu (Peminjaman Aktif paling atas, sisanya urut tanggal terbaru ke terlama)
            npcRecords.Sort((recordA, recordB) =>
            {
                // Aturan 1: Jika statusnya beda (satu masih dipinjam, satu sudah kembali), utamakan yang Borrowing
                if (recordA.status == LoanStatus.Borrowing && recordB.status != LoanStatus.Borrowing) return -1;
                if (recordA.status != LoanStatus.Borrowing && recordB.status == LoanStatus.Borrowing) return 1;

                // Aturan 2: Jika status sama-sama Borrowing atau sama-sama Returned, urutkan berdasarkan Tanggal Pinjam terbaru (Descending)
                return recordB.loanDate.CompareTo(recordA.loanDate);
            });

            // 4. Spawn Baris Transaksi ke Tabel
            for (int i = 0; i < npcRecords.Count; i++)
            {
                LoanEntry currentRecord = npcRecords[i];
                GameObject newRow = Instantiate(trnscMembPrefab, transactionTableContentParent);
                TrnscMembTable rowContainer = newRow.GetComponent<TrnscMembTable>();

                if (rowContainer != null)
                {
                    rowContainer.txtNo.text = (i + 1).ToString();
                    rowContainer.txtBookTitle.text = currentRecord.bookId.ToString("D4");
                    rowContainer.txtLoanDate.text = currentRecord.loanDateStr;
                    rowContainer.txtDueDate.text = currentRecord.dueDateStr;
                    
                    // Cek jika belum dikembalikan, tulis strip (-)
                    rowContainer.txtReturnDate.text = string.IsNullOrEmpty(currentRecord.returnDateStr) ? "-" : currentRecord.returnDateStr;
                    
                    rowContainer.txtStatus.text = currentRecord.status.ToString();
                }
            }
        }
        gameObject.SetActive(true);
    }

    public void ClickUpdate()
    {
        if (currentNpc != null)
        {
            System.DateTime today = new System.DateTime(2025, 9, 14);
            System.DateTime newExpDate = today.AddMonths(6);
            currentNpc.cardExpDate = newExpDate;
            txtExpDate.text = currentNpc.cardExpDate.ToString("dd/MM/yyyy");
        }
    }
}
