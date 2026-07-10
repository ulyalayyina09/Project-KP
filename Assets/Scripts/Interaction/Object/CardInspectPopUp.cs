using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardInspectPopUp : MonoBehaviour
{
    [SerializeField] private Image cardImg;
    [SerializeField] private TextMeshProUGUI cardId;
    [SerializeField] private TextMeshProUGUI cardName;
    [SerializeField] private TextMeshProUGUI cardAddress;
    [SerializeField] private TextMeshProUGUI cardBirth;
    [SerializeField] private TextMeshProUGUI cardExp;

    public void OpenPopUp(NPCDataTemplate npcData)
    {
        cardId.text = "#Member - " + npcData.npcId.ToString("D4");
        cardName.text = npcData.npcFirstName + " " + npcData.npcLastName;
        cardAddress.text = npcData.npcAddress;
        cardBirth.text = npcData.npcBirthDate.ToString("dd MMMM yyyy");
        cardExp.text = npcData.cardExpDate.ToString("dd/MM/yyyy");

        gameObject.SetActive(true);
    }
}
