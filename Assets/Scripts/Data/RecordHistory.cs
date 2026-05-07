using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] // Agar muncul di Inspector
public class LoanEntry
{
    public string loanId;
    public int bookId;
    public int npcId;
    public string npcName;
    public string bookTitle;
    
    [Header("Time Info")]
    public System.DateTime loanDate;     
    public System.DateTime dueDate; 
    public System.DateTime? returnDate = null;   

    [Header("Time Info (Read Only)")]
    public string loanDateStr;
    public string dueDateStr;
    public string returnDateStr;

    [Header("Status")]
    public LoanStatus status;       // Borrowing, Returned, Overdue
    public BookCondition condition = BookCondition.Good;    // kosong dulu
}

public class RecordHistory : MonoBehaviour
{
    public List<LoanEntry> allRecords = new List<LoanEntry>();

    public void AddRecord(LoanEntry addEntry)
    {
        // Otomatisasi ID berdasarkan jumlah record yang ada
        string newID = "HIS-" + (allRecords.Count + 1).ToString("D3"); 
        addEntry.loanId = newID;
        
        allRecords.Add(addEntry);
    }
}

public enum LoanStatus
{
    Borrowing,  // Sedang meminjam
    Returned,   // Sudah dikembalikan
    Overdue     // Terlambat mengembalikan
}

public enum BookCondition
{
    Good,       // Bagus
    Damaged,    // Rusak
    Lost        // Hilang
}