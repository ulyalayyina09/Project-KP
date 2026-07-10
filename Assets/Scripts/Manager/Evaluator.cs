using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evaluator : MonoBehaviour
{
    [Header("Date Reference:")]
    [SerializeField] private int year = 2025;
    [SerializeField] private int month = 9;
    [SerializeField] private int day = 14;
    private System.DateTime todayDate;

    [Header("Score Record:")]
    [SerializeField] private int correctDcs = 0;
    [SerializeField] private int wrongDcs = 0;

    void Awake()
    {
        todayDate = new System.DateTime(year, month, day);
    }

    public void EvaluateExpCard(NPCDataTemplate npcData, bool playerAccepted)
    {
        if (npcData == null) return;

        bool isExpired = npcData.cardExpDate < todayDate; //true

        if (isExpired)
        {
            if (!playerAccepted)
            {
                CorrectAction();
            }
            else
            {
                WrongAction();
            }
        }
        else
        {
            if (playerAccepted)
            {
                CorrectAction();
            }
            else
            {
                WrongAction();
            }
        }
    }

    private void CorrectAction()
    {
        correctDcs++;
        Debug.Log("Correct Decision! Total Correct: " + correctDcs);
    }

    private void WrongAction()
    {
        wrongDcs++;
        Debug.Log("Wrong Decision! Total Wrong: " + wrongDcs);
    }
}
