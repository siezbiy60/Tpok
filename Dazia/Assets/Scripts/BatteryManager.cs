using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryManager : MonoBehaviour
{



    public Light flashlight; // Fenerin ýþýk kaynaðý
    public float maxBattery = 100f; // Maksimum batarya seviyesi
    public float battery = 100f; // Mevcut batarya seviyesi
    public float drainRate = 0.5f; // Batarya boþalým hýzý (daha düþük deðer gerçekçi sonuç verir)
    public float fadeOutSpeed = 0.5f; // Fenerin sönme hýzý

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

            if (battery <= 0)
            {
                flashlight.intensity = Mathf.Lerp(flashlight.intensity, 0, fadeOutSpeed * Time.deltaTime);
                if (flashlight.intensity <= 0.01f)
                {
                    flashlight.enabled = false;
                    flashlight.intensity = 0;
                    isDraining = false;
                }
            }
            else
            {
                flashlight.intensity = Mathf.Lerp(0.5f, 1, battery / maxBattery); // Daha gerçekçi ýþýk geçiþi
            }
        }
    }
}