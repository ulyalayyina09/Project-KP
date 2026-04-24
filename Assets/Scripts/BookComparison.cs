using UnityEngine;

public class BookComparison : MonoBehaviour 
{
    [Header("UI References")]
    public SpriteRenderer uiBookRenderer; 
    public Transform uiDamageContainer;   
    public GameObject uiDamagePrefab;     

    // Fungsi Utama: Penampung instruksi sinkronisasi
    public void SyncBookData(GameObject source)
    {
        // --- BAGIAN 1: AKSES KOMPONEN ---
        // Syntax: [Tipe Komponen] [Nama Bebas] = [Objek].GetComponent<[Tipe]>();
        // Tujuannya: Ngambil 'otak' visual buku yang diklik (source).
        SpriteRenderer sourceRend = source.GetComponent<SpriteRenderer>();

        // DEBUG POINT: Kalau console error "NullReference", berarti 'source' gak punya SpriteRenderer.
        if (sourceRend == null) return; 

        // --- BAGIAN 2: ASSIGNMENT (PENUGASAN) ---
        // Syntax: [Target] = [Sumber];
        // Tujuannya: Copy warna dari buku meja ke buku UI.
        uiBookRenderer.color = sourceRend.color;

        // --- BAGIAN 3: CLEANUP (PEMBERSIHAN) ---
        // Syntax: foreach ([Tipe] [Nama] in [Koleksi])
        // Tujuannya: Ngehapus damage sisa dari buku sebelumnya yang masih nempel di UI.
        foreach (Transform anak in uiDamageContainer) 
        {
            Destroy(anak.gameObject); 
        }

        // --- BAGIAN 4: LOOPING & INSTANTIATION ---
        // Syntax: source.transform otomatis jadi list semua anak di bawahnya.
        foreach (Transform child in source.transform)
        {
            // 4a. Ambil data dari child asli (Coretan di meja)
            SpriteRenderer childRend = child.GetComponent<SpriteRenderer>();

            // 4b. Buat Replika di UI
            // Instantiate(ObjekApa, DiMana)
            GameObject uiDmg = Instantiate(uiDamagePrefab, uiDamageContainer);

            // 4c. DATA SYNC (INTI DEBUG LO)
            // Mengakses SpriteRenderer milik replika yang baru lahir.
            SpriteRenderer uiDmgRend = uiDmg.GetComponent<SpriteRenderer>();

            // Copy Gambar:
            uiDmgRend.sprite = childRend.sprite;

            // Copy Posisi: 
            // Pake localPosition supaya koordinatnya (0,0) dihitung dari tengah uiDamageContainer.
            uiDmg.transform.localPosition = child.localPosition;

            // Copy Sorting:
            // uiBookRenderer.sortingOrder + 1 supaya coretan nggak "masuk" ke dalem buku UI.
            uiDmgRend.sortingOrder = uiBookRenderer.sortingOrder + 1;
        }
    }
}