using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeInteraction : MonoBehaviour
{
    public GameObject interactionText;  // UI Text'i burada tutacaðýz

    private void Start()
    {
        interactionText.SetActive(false);  // Baþlangýçta metni gizle
    }

    // Karakter trigger içine girdiðinde çalýþýr
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))  // Sadece oyuncu karakteri
        {
            interactionText.SetActive(true);  // UI Text görünür hale gelir
        }
    }

    // Karakter trigger'dan çýktýðýnda çalýþýr
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
            // Buraya etkileþimde ne olmasýný istiyorsan onu yaz
            Debug.Log("E tuþuna basýldý, etkileþim gerçekleþti!");
        }
    }
}