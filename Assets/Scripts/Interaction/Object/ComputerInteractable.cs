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
        computerCanvas.SetActive(true);
<<<<<<< Updated upstream

    }

    public void OnUnselect()
    {
        spriteRenderer.color = new Color(0.23f, 0.23f, 0.23f);
        computerCanvas.SetActive(false);
=======
>>>>>>> Stashed changes
    }
}
