using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class NpcRowContainer : MonoBehaviour
{
    public TextMeshProUGUI txtNo;
    public TextMeshProUGUI txtID;
    public TextMeshProUGUI txtName;
    public TextMeshProUGUI txtStatus;

    private NPCDataTemplate assignedNpc;
    private MemberDetailPanel detailPanelScript;

    public void SetupRow(NPCDataTemplate npc, MemberDetailPanel panelScript)
    {
        assignedNpc = npc;
        detailPanelScript = panelScript;

        EventTrigger trigger = GetComponent<EventTrigger>();
        if (trigger == null) trigger = gameObject.AddComponent<EventTrigger>();

        trigger.triggers.Clear();

        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerClick;

        entry.callback.AddListener((data) => { OnRowClicked(); });

        trigger.triggers.Add(entry);
    }

    private void OnRowClicked()
    {
        if (assignedNpc != null && detailPanelScript != null)
        {
            detailPanelScript.OpenDetail(assignedNpc);
        }
    }
}