using UnityEngine;

public class NPCAssembler : MonoBehaviour
{
    public NPCBank bank; // Referensi ke gudang aset

    [Header("Target Renderers")]
    public SpriteRenderer bodyRenderer;
    public SpriteRenderer faceRenderer;
    public SpriteRenderer fronthairRenderer;
    public SpriteRenderer backhairRenderer;
    public SpriteRenderer outfitRenderer;

    // Fungsi untuk merakit visual berdasarkan data NPC
    public void Assemble(NPCDataTemplate data)
    {
        if (bank == null) Debug.LogError("Woi, Bank-nya belum dipasang di Inspector!");
        if (bodyRenderer == null) Debug.LogError("Woi, Body Renderer-nya belum dipasang!");

        bodyRenderer.sprite = bank.skinIndex[data.skinIndeX];

        // 2. Pasang Gambar Muka
        faceRenderer.sprite = bank.faceIndex[data.faceIndeX ];

        // 3. Pasang Gambar Rambut
        fronthairRenderer.sprite = bank.hairFrontIndex[data.hairFrontIndeX];
        backhairRenderer.sprite = bank.hairBackIndex[data.hairBackIndeX];

        // 4. Pasang Gambar Baju
        outfitRenderer.sprite = bank.outfitIndex[data.outfitIndeX];
        
        Debug.Log("Visual dirakit untuk ID: " + data.npcID);
    }
}