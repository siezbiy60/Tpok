using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightControl : MonoBehaviour
{
    public Light flashlight; // Fenerin ýþýk kaynaðý
    public float maxBattery = 100f; // Maksimum batarya seviyesi
    public float battery = 100f; // Mevcut batarya seviyesi
    public float drainRate = 1f; // Batarya boþalým hýzý
    public float fadeOutSpeed = 1f; // Fenerin sönme hýzý

    private bool isDraining = false; // Bataryanýn boþalmasýný kontrol etme

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            flashlight.enabled = !flashlight.enabled;
            isDraining = flashlight.enabled;
        }

        if (isDraining)
        {
            battery -= drainRate * Time.deltaTime;
            battery = Mathf.Clamp(battery, 0, maxBattery);

            // Feneri yavaþça sönme
            if (battery <= 0)
            {
                flashlight.intensity = Mathf.Lerp(flashlight.intensity, 0, fadeOutSpeed * Time.deltaTime);
                if (flashlight.intensity <= 0.01f) // Fener tamamen sönene kadar bekle
                {
                    flashlight.enabled = false;
                    flashlight.intensity = 0; // Tamamen kapalý durumda býrak
                    isDraining = false;
                }
            }
            else
            {
                // Fenerin þiddetini batarya seviyesine göre ayarla
                flashlight.intensity = Mathf.Lerp(0, 1, battery / maxBattery);
            }
        }
    }
}