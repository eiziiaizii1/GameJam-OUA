using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 3f; // Düþmanýn hareket hýzý
    public float moveDistance = 0.5f; // Düþmanýn hareket edeceði maksimum mesafe

    private Vector3 startingPosition; // Düþmanýn baþlangýç pozisyonu
    private float direction = 1f; // Hareket yönü (+1 saða, -1 sola)

    void Start()
    {
        startingPosition = transform.position; // Baþlangýç pozisyonunu kaydet
    }

    void Update()
    {
        // Düþmaný ileri geri hareket ettir
        transform.Translate(Vector3.right * direction * moveSpeed * Time.deltaTime);

        // Eðer düþman maksimum mesafeyi aþtýysa, yönü tersine çevir
        if (Mathf.Abs(transform.position.x - startingPosition.x) >= moveDistance)
        {
            direction *= -1f; // Yönü tersine çevir
        }
    }
}