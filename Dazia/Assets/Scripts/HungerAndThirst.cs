using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HungerAndThirst : MonoBehaviour
{
    public Slider hungerSlider; // A�l�k bar�
    public Slider thirstSlider; // Susuzluk bar�
    public float hunger = 100f; // Ba�lang�� a�l�k seviyesi
    public float thirst = 100f; // Ba�lang�� susuzluk seviyesi
    public float hungerDecreaseRate = 1f; // A�l�k azal�m h�z�
    public float thirstDecreaseRate = 1f; // Susuzluk azal�m h�z�
    public float hungerIncreaseAmount = 20f; // Yiyecek ile art�� miktar�
    public float thirstIncreaseAmount = 20f; // ��me ile art�� miktar�

    private void Start()
    {
        // Ba�lang��ta UI de�erlerini g�ncelle
        UpdateUI();
    }

    private void Update()
    {
        // A�l�k ve susuzluk seviyelerini azalt
        hunger -= hungerDecreaseRate * Time.deltaTime;
        thirst -= thirstDecreaseRate * Time.deltaTime;

        // A�l�k ve susuzluk seviyelerini s�n�rlama
        hunger = Mathf.Clamp(hunger, 0, 100);
        thirst = Mathf.Clamp(thirst, 0, 100);

        // UI'yi g�ncelle
        UpdateUI();
    }

    private void UpdateUI()
    {
        hungerSlider.value = hunger;
        thirstSlider.value = thirst;
    }

    // Yiyecek t�ketimi
    public void EatFood()
    {
        hunger = Mathf.Clamp(hunger + hungerIncreaseAmount, 0, 100);
    }

    // ��me
    public void Drink()
    {
        thirst = Mathf.Clamp(thirst + thirstIncreaseAmount, 0, 100);
    }
}