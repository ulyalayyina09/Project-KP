using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject computerColor;
    [SerializeField] private GameObject computerCanvas;
    private SpriteRenderer spriteRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void OnSelect()
    {
        spriteRenderer.color = new Color(0.3f, 0.3f, 0.3f, 1f);
        computerCanvas.SetActive(true);

    }

    public void OnUnselect()
    {
        spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
        computerCanvas.SetActive(false);
    }

    public void Open()
    {
        
    }
}
