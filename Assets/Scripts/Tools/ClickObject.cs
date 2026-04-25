using UnityEngine;
using UnityEngine.Events;

public class ClickObject : MonoBehaviour
{
    [Header("Events")]
    public UnityEvent OnClicked;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Debug.Log("Clicked " + gameObject.name);
        OnClicked.Invoke();
    }
}
