using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBook : MonoBehaviour
{
    private SpriteRenderer rend;

    [Header("Damage settings")]
    public GameObject dmgPrefab;
    public Sprite[] dmgdImg;
    public int maxDmg = 4;
     
    // Start is called before the first frame update
    void Start()
    {
        //sementara rand warna duls
        rend = GetComponent<SpriteRenderer>();

        float r = Random.value;
        float g = Random.value;
        float b = Random.value;

        Color randomize = new Color(r, g, b, 1f);

        rend.color = randomize;

        Vector3 bookScale = transform.localScale;

        //jumlah damage
        int dmgTotal = Random.Range(0, maxDmg + 1);
        for (int i = 0; i < dmgTotal; i++)
        {
            GameObject newDmg = Instantiate(dmgPrefab, this.transform);
            
            int randIndex = Random.Range(0, dmgdImg.Length);

            Sprite choosen = dmgdImg[randIndex];
            newDmg.GetComponent<SpriteRenderer>().sprite = choosen;

            float randomX = Random.Range(-rend.bounds.extents.x, rend.bounds.extents.x) / bookScale.x;
            float randomY = Random.Range(-rend.bounds.extents.y, rend.bounds.extents.y) / bookScale.y;

            newDmg.transform.localPosition = new Vector3(randomX, randomY, 0f);
            newDmg.GetComponent<SpriteRenderer>().sortingOrder = rend.sortingOrder + 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
