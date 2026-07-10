using UnityEngine;
using UnityEngine.EventSystems;

public class InteractionManager : MonoBehaviour
{
<<<<<<< Updated upstream
    private IInteractable currentSelected;

    // Update is called once per frame
=======
>>>>>>> Stashed changes
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Cek jika yang diklik pemain adalah UI Tombol/Panel di Canvas, jangan tembus ke Raycast object 2D di meja
            if (EventSystem.current != null && EventSystem.current.IsPointerOverGameObject()) 
                return;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if (hit.collider != null)
            {
                IInteractable interactable = hit.collider.GetComponent<IInteractable>();
                if (interactable != null)
                {
<<<<<<< Updated upstream
                    if (currentSelected != null && !currentSelected.Equals(null))
                    {
                        currentSelected.OnUnselect();
                    }
                    currentSelected = interactable;
                    currentSelected.OnSelect();
=======
                    // Langsung eksekusi aksi interaksinya (buka pop-up inspeksi)
                    interactable.OnSelect();
>>>>>>> Stashed changes
                }
            }
        }
    }
}