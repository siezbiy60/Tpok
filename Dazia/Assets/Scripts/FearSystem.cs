using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



    public class FearSystem : MonoBehaviour
    {
        public Slider fearBar;  // UI'daki Slider'� referans al
        public float maxFear = 100f;  // Korku bar�n�n maksimum de�eri
        private float currentFear;  // Mevcut korku seviyesi

        // Ba�lang��ta korku seviyesini maksimum olarak ayarla
        void Start()
        {
            currentFear = maxFear;
            fearBar.maxValue = maxFear;
            fearBar.value = currentFear;
        }

        // Korkuyu artt�r veya azalt
        public void ModifyFear(float amount)
        {
            currentFear += amount;
            currentFear = Mathf.Clamp(currentFear, 0, maxFear);  // 0 ile maksimum korku aras�nda tut
            fearBar.value = currentFear;

            // E�er korku 0'a ula��rsa karakteri �ld�r
            if (currentFear <= 0)
            {
                Die();
            }
        }

        // Karakterin �lme fonksiyonu
        void Die()
        {
            Debug.Log("Karakter korkudan �ld�!");
            // Buraya karakterin �lme animasyonu veya ba�ka bir i�levsellik eklenebilir
        }
        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                ModifyFear(-20f);  // Korkuyu 20 azalt
            }
        }
    }
