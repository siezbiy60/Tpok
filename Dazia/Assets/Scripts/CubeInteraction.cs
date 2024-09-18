using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeInteraction : MonoBehaviour
{
    public GameObject interactionText;  // UI Text'i burada tutaca��z

    private void Start()
    {
        interactionText.SetActive(false);  // Ba�lang��ta metni gizle
    }

    // Karakter trigger i�ine girdi�inde �al���r
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))  // Sadece oyuncu karakteri
        {
            interactionText.SetActive(true);  // UI Text g�r�n�r hale gelir
        }
    }

    // Karakter trigger'dan ��kt���nda �al���r
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactionText.SetActive(false);  // UI Text tekrar gizlenir
        }
    }
    void Update()
    {
        if (interactionText.activeSelf && Input.GetKeyDown(KeyCode.E))
        {
            // Buraya etkile�imde ne olmas�n� istiyorsan onu yaz
            Debug.Log("E tu�una bas�ld�, etkile�im ger�ekle�ti!");
        }
    }
}