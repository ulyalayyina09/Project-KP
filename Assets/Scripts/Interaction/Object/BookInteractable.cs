using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookInteractable : MonoBehaviour, IInteractable
{
    private BookParts bookParts;
    private Decisioner decisioner;
    
    // Start is called before the first frame update
    void Start()
    {
        bookParts = GetComponent<BookParts>();
        decisioner = FindObjectOfType<Decisioner>();
    }

    // Update is called once per frame
    public void OnSelect()
    {
<<<<<<< Updated upstream
        decisioner.SelectBook(bookParts);
        bookParts.selectedOutline.SetActive(true);
    }

    public void OnUnselect()
    {
        decisioner.SelectBook(null);
        bookParts.selectedOutline.SetActive(false);
    }
}
=======
        bookInspectPopUp.OpenPopUp(bookParts.bookData);
    }
}
>>>>>>> Stashed changes
