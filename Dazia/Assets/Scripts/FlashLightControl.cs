using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightControl : MonoBehaviour
{
    public Light flashlight; // Fenerin ���k kayna��
    public float maxBattery = 100f; // Maksimum batarya seviyesi
    public float battery = 100f; // Mevcut batarya seviyesi
    public float drainRate = 1f; // Batarya bo�al�m h�z�
    public float fadeOutSpeed = 1f; // Fenerin s�nme h�z�

    private bool isDraining = false; // Bataryan�n bo�almas�n� kontrol etme

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

            // Feneri yava��a s�nme
            if (battery <= 0)
            {
                flashlight.intensity = Mathf.Lerp(flashlight.intensity, 0, fadeOutSpeed * Time.deltaTime);
                if (flashlight.intensity <= 0.01f) // Fener tamamen s�nene kadar bekle
                {
                    flashlight.enabled = false;
                    flashlight.intensity = 0; // Tamamen kapal� durumda b�rak
                    isDraining = false;
                }
            }
            else
            {
                // Fenerin �iddetini batarya seviyesine g�re ayarla
                flashlight.intensity = Mathf.Lerp(0, 1, battery / maxBattery);
            }
        }
    }
}