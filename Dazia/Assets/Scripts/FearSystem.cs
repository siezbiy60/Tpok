using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



    public class FearSystem : MonoBehaviour
    {
        public Slider fearBar;  // UI'daki Slider'ý referans al
        public float maxFear = 100f;  // Korku barýnýn maksimum deðeri
        private float currentFear;  // Mevcut korku seviyesi

        // Baþlangýçta korku seviyesini maksimum olarak ayarla
        void Start()
        {
            currentFear = maxFear;
            fearBar.maxValue = maxFear;
            fearBar.value = currentFear;
        }

        // Korkuyu arttýr veya azalt
        public void ModifyFear(float amount)
        {
            currentFear += amount;
            currentFear = Mathf.Clamp(currentFear, 0, maxFear);  // 0 ile maksimum korku arasýnda tut
            fearBar.value = currentFear;

            // Eðer korku 0'a ulaþýrsa karakteri öldür
            if (currentFear <= 0)
            {
                Die();
            }
        }

        // Karakterin ölme fonksiyonu
        void Die()
        {
            Debug.Log("Karakter korkudan öldü!");
            // Buraya karakterin ölme animasyonu veya baþka bir iþlevsellik eklenebilir
        }
        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                ModifyFear(-20f);  // Korkuyu 20 azalt
            }
        }
    }
