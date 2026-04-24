using UnityEngine;

public class CustomerMovement : MonoBehaviour
{
    [Header("Useless 4 now")]
    public float speed = 5f;
    public Vector3 targetPos;
    private bool isMoving = false;

    [Header("Items")]
    public GameObject book;
    public GameObject card;
    public Vector3 bookSlot;
    public Vector3 cardSlot;

    public void Walking(Vector3 destination)
    {
        targetPos = destination;
        isMoving = true;
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Cust walk to table
        Walking(targetPos);
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            //walk to target
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
            //stop
            if (Vector3.Distance(transform.position, targetPos) < 0.1f)
            {
                isMoving = false;
                Debug.Log("New customer arrived!");
                PlaceItems();
            }
        }
    }

    void PlaceItems()
    {
        //unattached from cust
        book.transform.SetParent(null);
        card.transform.SetParent(null);
        //pindah ke meja
        book.transform.position = bookSlot;
        card.transform.position = cardSlot;
        //munculin aka set true
        book.SetActive(true);
        card.SetActive(true);
    }
}
