using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InteractionManager : MonoBehaviour
{
    private IInteractable currentSelected;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if (hit.collider != null)
            {
                IInteractable interactable = hit.collider.GetComponent<IInteractable>();
                if (interactable != null)
                {
                    if (currentSelected != null && !currentSelected.Equals(null))
                    {
                        currentSelected.OnUnselect();
                    }
                    currentSelected = interactable;
                    currentSelected.OnSelect();
                }
            }

            else
            {
                if (EventSystem.current != null && EventSystem.current.IsPointerOverGameObject()) return;
                else
                {
                    if (currentSelected != null)
                    {
                        if (currentSelected.Equals(null) == false)
                        {
                            currentSelected.OnUnselect();
                        }
                        currentSelected = null;
                    }
                }
            }
        
        }
    }
}
