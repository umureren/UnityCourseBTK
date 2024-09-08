using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleController2D : MonoBehaviour
{
    public float moveSpeed = 5f;  // Araç hareket hızı
    public float rotationSpeed = 200f;  // Araç dönüş hızı

    private Rigidbody2D rb;  // Araç için Rigidbody2D bileşeni
    private float moveInput;  // İleri/geri hareket girişi
    private float turnInput;  // Dönüş girişi

    void Start()
    {
        // Rigidbody2D bileşenini al
        rb = GetComponent<Rigidbody2D>();

        // Eğer Rigidbody2D yoksa uyarı ver
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D bileşeni eksik! Lütfen 'police' nesnesine Rigidbody2D ekleyin.");
        }
    }

    void Update()
    {
        // Eğer Rigidbody2D yoksa, işlemi durdur
        if (rb == null) return;

        // Hareket ve dönüş girişlerini al
        moveInput = Input.GetAxis("Vertical");  // 'W' ve 'S' veya yukarı ve aşağı ok tuşları
        turnInput = Input.GetAxis("Horizontal");  // 'A' ve 'D' veya sol ve sağ ok tuşları
    }

    void FixedUpdate()
    {
        // Araç ileri veya geri hareket eder
        rb.linearVelocity = transform.up * moveInput * moveSpeed;

        // Araç sağa veya sola döner
        rb.angularVelocity = -turnInput * rotationSpeed;
    }
}
