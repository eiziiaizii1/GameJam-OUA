using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 3f; // D��man�n hareket h�z�
    public float moveDistance = 0.5f; // D��man�n hareket edece�i maksimum mesafe

    private Vector3 startingPosition; // D��man�n ba�lang�� pozisyonu
    private float direction = 1f; // Hareket y�n� (+1 sa�a, -1 sola)

    void Start()
    {
        startingPosition = transform.position; // Ba�lang�� pozisyonunu kaydet
    }

    void Update()
    {
        // D��man� ileri geri hareket ettir
        transform.Translate(Vector3.right * direction * moveSpeed * Time.deltaTime);

        // E�er d��man maksimum mesafeyi a�t�ysa, y�n� tersine �evir
        if (Mathf.Abs(transform.position.x - startingPosition.x) >= moveDistance)
        {
            direction *= -1f; // Y�n� tersine �evir
        }
    }
}