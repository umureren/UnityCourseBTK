using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoCarMove : MonoBehaviour
{
    public GameObject prefab1;  // Ýlk prefab
    public GameObject prefab2;  // Ýkinci prefab

    public float speed = 5f;  // Hareket hýzý
    public float resetPositionX = 30f;  // Saðdan sola hareket için baþlangýç konumu (sað)
    public float endPositionX = -20f;  // Bitiþ konumu (sol)

    private GameObject instance1;  // Ýlk prefab'ýn örneði
    private GameObject instance2;  // Ýkinci prefab'ýn örneði

    private Vector2 initialPosition1;  // Ýlk prefab'ýn baþlangýç pozisyonu
    private Vector2 initialPosition2;  // Ýkinci prefab'ýn baþlangýç pozisyonu

    void Start()
    {
        // Baþlangýç pozisyonlarýný belirle
        initialPosition1 = new Vector2(21f, 1f);  // Prefab1'in baþlangýç pozisyonu
        initialPosition2 = new Vector2(26f, 1f);  // Prefab2'nin baþlangýç pozisyonu

        // Prefab'larý yarat ve baþlangýç pozisyonlarýna yerleþtir
        instance1 = Instantiate(prefab1, initialPosition1, Quaternion.identity);
        instance2 = Instantiate(prefab2, initialPosition2, Quaternion.identity);
    }

    void Update()
    {
        // Prefab'larý sýrayla hareket ettirin
        MovePrefab(instance1, initialPosition1);
        MovePrefab(instance2, initialPosition2);
    }

    void MovePrefab(GameObject prefabInstance, Vector2 initialPosition)
    {
        // Prefab sola doðru hareket eder
        prefabInstance.transform.Translate(Vector2.left * speed * Time.deltaTime);

        // Prefab soldan çýktýysa, baþlangýç pozisyonuna geri döner
        if (prefabInstance.transform.position.x < endPositionX)
        {
            prefabInstance.transform.position = new Vector2(resetPositionX, prefabInstance.transform.position.y);
        }
    }
}
