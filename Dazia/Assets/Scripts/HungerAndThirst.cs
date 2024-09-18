using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HungerAndThirst : MonoBehaviour
{
    public Slider hungerSlider; // Açlýk barý
    public Slider thirstSlider; // Susuzluk barý
    public float hunger = 100f; // Baþlangýç açlýk seviyesi
    public float thirst = 100f; // Baþlangýç susuzluk seviyesi
    public float hungerDecreaseRate = 1f; // Açlýk azalým hýzý
    public float thirstDecreaseRate = 1f; // Susuzluk azalým hýzý
    public float hungerIncreaseAmount = 20f; // Yiyecek ile artýþ miktarý
    public float thirstIncreaseAmount = 20f; // Ýçme ile artýþ miktarý

    private void Start()
    {
        // Baþlangýçta UI deðerlerini güncelle
        UpdateUI();
    }

    private void Update()
    {
        // Açlýk ve susuzluk seviyelerini azalt
        hunger -= hungerDecreaseRate * Time.deltaTime;
        thirst -= thirstDecreaseRate * Time.deltaTime;

        // Açlýk ve susuzluk seviyelerini sýnýrlama
        hunger = Mathf.Clamp(hunger, 0, 100);
        thirst = Mathf.Clamp(thirst, 0, 100);

        // UI'yi güncelle
        UpdateUI();
    }

    private void UpdateUI()
    {
        hungerSlider.value = hunger;
        thirstSlider.value = thirst;
    }

    // Yiyecek tüketimi
    public void EatFood()
    {
        hunger = Mathf.Clamp(hunger + hungerIncreaseAmount, 0, 100);
    }

    // Ýçme
    public void Drink()
    {
        thirst = Mathf.Clamp(thirst + thirstIncreaseAmount, 0, 100);
    }
}