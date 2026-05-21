using UnityEngine;

public class NPCAssembler : MonoBehaviour
{
    [SerializeField] private NPCBank bank; 

    [Header("Target Renderers")]
    [SerializeField] private SpriteRenderer bodyRenderer;
    [SerializeField] private SpriteRenderer faceRenderer;
    [SerializeField] private SpriteRenderer fronthairRenderer;
    [SerializeField] private SpriteRenderer backhairRenderer;
    [SerializeField] private SpriteRenderer outfitRenderer;

    public void Assemble(NPCDataTemplate data)
    {
        if (bank == null) Debug.LogError("NPC Bank reference is missing in NPCAssembler.");
        if (bodyRenderer == null) Debug.LogError("Body Renderer reference is missing in NPCAssembler.");
        if (faceRenderer == null) Debug.LogError("Face Renderer reference is missing in NPCAssembler.");
        if (fronthairRenderer == null) Debug.LogError("Front Hair Renderer reference is missing in NPCAssembler.");
        if (backhairRenderer == null) Debug.LogError("Back Hair Renderer reference is missing in NPCAssembler.");
        if (outfitRenderer == null) Debug.LogError("Outfit Renderer reference is missing in NPCAssembler.");
        
        bodyRenderer.sprite = bank.skin[data.skinIndex];

        faceRenderer.sprite = bank.face[data.faceIndex];

        fronthairRenderer.sprite = bank.hairFront[data.hairFrontIndex];
        backhairRenderer.sprite = bank.hairBack[data.hairBackIndex];

        outfitRenderer.sprite = bank.outfit[data.outfitIndex];

        Debug.Log("Visual created for NPC ID: " + data.npcId);
    }
}