using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI transactionQuotaTxt;
    [SerializeField] private int maxTransactions = 10;
    private int remainingQuota;
    private bool isGameOver = false;
    
    // Start is called before the first frame update
    void Start()
    {
        remainingQuota = maxTransactions;
        UpdateCountdownUI();
    }

    public void DecreaseQuota()
    {
        if (isGameOver == true) return;

        remainingQuota--;
        UpdateCountdownUI();

        if (remainingQuota <= 0)
        {
            EndLevel();
        }
    }

    private void UpdateCountdownUI()
    {
        transactionQuotaTxt.text = "Transaction Left: " + remainingQuota;
    }

    private void EndLevel()
    {
        isGameOver = true;
        Application.Quit();

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
