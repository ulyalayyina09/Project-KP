using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBook : MonoBehaviour
{
    public BookDataInstance bookDataInstance;

    // Start is called before the first frame update
    void Start()
    {
        bookDataInstance.GenerateBooks();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
