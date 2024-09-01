using UnityEngine;

public class ShopSpawner : MonoBehaviour
{
    public GameObject[] shops; // Array yang menyimpan prefab toko
    public Vector3[] spawnPositions; // Array yang menyimpan posisi spawn

    void Start()
    {
        ShuffleArray(shops); // Mengacak urutan toko
        ShuffleArray(spawnPositions); // Mengacak urutan posisi spawn
        SpawnShops(); // Men-spawn toko
    }

    void ShuffleArray<T>(T[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            T temp = array[i];
            int randomIndex = Random.Range(i, array.Length);
            array[i] = array[randomIndex];
            array[randomIndex] = temp;
        }
    }

    void SpawnShops()
    {
        for (int i = 0; i < shops.Length; i++)
        {
            GameObject shop = Instantiate(shops[i], spawnPositions[i], Quaternion.identity);
            shop.AddComponent<RotateOnCollision>();
        }
    }
}

public class RotateOnCollision : MonoBehaviour
{
    public Vector3 rotationAngleToko1 = new Vector3(0f, 270f, 0f); // Rotasi untuk Toko1
    public Vector3 rotationAngleToko2 = new Vector3(0f, 0f, 0f);   // Rotasi untuk Toko2
    public Vector3 rotationAngleToko3 = new Vector3(0f, 0f, 0f);   // Rotasi untuk Toko3

    private void OnTriggerEnter(Collider other)
    {
        // Memastikan hanya berinteraksi dengan objek yang memiliki tag "Toko1", "Toko2", atau "Toko3"
        if (other.CompareTag("Toko1"))
        {
            Debug.Log("Rotasi Toko1");
            transform.rotation = Quaternion.Euler(rotationAngleToko1);
        }
        else if (other.CompareTag("Toko2"))
        {
            Debug.Log("Rotasi Toko2");
            transform.rotation = Quaternion.Euler(rotationAngleToko2);
        }
        else if (other.CompareTag("Toko3"))
        {
            Debug.Log("Rotasi Toko3");
            transform.rotation = Quaternion.Euler(rotationAngleToko3);
        }
    }
}

