using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoCarMove : MonoBehaviour
{
    public GameObject prefab1;  // �lk prefab
    public GameObject prefab2;  // �kinci prefab

    public float speed = 5f;  // Hareket h�z�
    public float resetPositionX = 30f;  // Sa�dan sola hareket i�in ba�lang�� konumu (sa�)
    public float endPositionX = -20f;  // Biti� konumu (sol)

    private GameObject instance1;  // �lk prefab'�n �rne�i
    private GameObject instance2;  // �kinci prefab'�n �rne�i

    private Vector2 initialPosition1;  // �lk prefab'�n ba�lang�� pozisyonu
    private Vector2 initialPosition2;  // �kinci prefab'�n ba�lang�� pozisyonu

    void Start()
    {
        // Ba�lang�� pozisyonlar�n� belirle
        initialPosition1 = new Vector2(21f, 1f);  // Prefab1'in ba�lang�� pozisyonu
        initialPosition2 = new Vector2(26f, 1f);  // Prefab2'nin ba�lang�� pozisyonu

        // Prefab'lar� yarat ve ba�lang�� pozisyonlar�na yerle�tir
        instance1 = Instantiate(prefab1, initialPosition1, Quaternion.identity);
        instance2 = Instantiate(prefab2, initialPosition2, Quaternion.identity);
    }

    void Update()
    {
        // Prefab'lar� s�rayla hareket ettirin
        MovePrefab(instance1, initialPosition1);
        MovePrefab(instance2, initialPosition2);
    }

    void MovePrefab(GameObject prefabInstance, Vector2 initialPosition)
    {
        // Prefab sola do�ru hareket eder
        prefabInstance.transform.Translate(Vector2.left * speed * Time.deltaTime);

        // Prefab soldan ��kt�ysa, ba�lang�� pozisyonuna geri d�ner
        if (prefabInstance.transform.position.x < endPositionX)
        {
            prefabInstance.transform.position = new Vector2(resetPositionX, prefabInstance.transform.position.y);
        }
    }
}
