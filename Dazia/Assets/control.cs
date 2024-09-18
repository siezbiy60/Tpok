using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Hareket hızını belirler

    void Update()
    {
        // Girdi al
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Hareket yönünü belirle
        Vector3 move = new Vector3(horizontal, 0, vertical) * moveSpeed * Time.deltaTime;

        // Karakteri hareket ettir
        transform.Translate(move);
    }
}
