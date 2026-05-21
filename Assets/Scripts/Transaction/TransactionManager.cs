using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransactionManager : MonoBehaviour
{
    [SerializeField] private RecordHistory history;

    public void Borrowing(NPCDataTemplate npc, string date)
    {
        var book = npc.bookRequested;
        
        npc.isBorrowing = true;
        npc.borrowingTotal += 1;
        npc.borrowedBookIds.Add(book.bookId);

        book.isBorrowed = true;
        book.isAvailable = false;

        System.DateTime lDate = System.DateTime.Parse(date);
        System.DateTime dDate = lDate.AddDays(7);

        LoanEntry entry = new LoanEntry
        {
            npcId = npc.npcId,
            npcName = npc.npcFirstName + " " + npc.npcLastName,
            bookId = book.bookId,
            bookTitle = book.bookTitle,
            loanDate = lDate,
            dueDate = dDate,
            status = LoanStatus.Borrowing,

            loanDateStr = lDate.ToString("yyyy-MM-dd"),
            dueDateStr = dDate.ToString("yyyy-MM-dd")
        };

        history.AddRecord(entry);

        book.currentLoanId = entry.loanId;
        npc.bookRequestId = 0;
    }

    public void Returning(NPCDataTemplate npc, BookDataTemplate book, string date)
    {
        npc.borrowingTotal -= 1;
        npc.borrowedBookIds.Remove(book.bookId);

        if (npc.borrowingTotal <= 0)
        {
            npc.borrowingTotal = 0;
            npc.isBorrowing = false;
        }

        book.isBorrowed = false;
        book.isAvailable = true;

        var record = history.allRecords.Find(r => r.loanId == book.currentLoanId);
        if (record != null)
        {
            System.DateTime rDate = System.DateTime.Parse(date);
            
            record.returnDate = rDate;
            record.status = LoanStatus.Returned;

            record.returnDateStr = rDate.ToString("yyyy-MM-dd");
        }

        book.currentLoanId = null;
        npc.bookRequestId = 0;
    }
}
