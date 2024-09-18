using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Karakterin transformu
    public Vector3 offset;   // Kamera ile karakter arasındaki mesafe
    public float smoothSpeed = 0.125f; // Kameranın hareket hızını yumuşatır

    void LateUpdate()
    {
        // Kameranın hedef pozisyonunu belirle
        Vector3 desiredPosition = player.position + offset;
        // Kamerayı hedef pozisyona yumuşak bir geçişle taşır
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
