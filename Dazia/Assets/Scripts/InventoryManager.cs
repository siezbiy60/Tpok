using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class InventoryManager : MonoBehaviour
    {
    public GameObject inventoryPanel; // Envanter paneli
    public GameObject inventorySlotPrefab; // Envanter slotu prefab�
    public Transform inventoryContent; // Envanter i�eri�i (panelin i�inde bir layout)
    public KeyCode toggleKey = KeyCode.I; // Envanteri a�ma tu�u

    private bool inventoryOpen = false; // Envanter a��k m�?
    private Dictionary<string, int> inventoryItems = new Dictionary<string, int>(); // E�yalar� saklamak i�in s�zl�k

    private void Update()
    {
        // Envanteri a�ma/kapama
        if (Input.GetKeyDown(toggleKey))
        {
            inventoryOpen = !inventoryOpen;
            inventoryPanel.SetActive(inventoryOpen);
        }
    }

    // E�yay� envantere ekleme
    public void AddItemToInventory(string itemName)
    {
        if (inventoryItems.ContainsKey(itemName))
        {
            inventoryItems[itemName]++; // Ayn� e�yadan bir tane daha ekle
        }
        else
        {
            inventoryItems[itemName] = 1; // Yeni e�ya ekle
        }

        UpdateInventoryUI(); // UI'yi g�ncelle
    }

    // Envanter UI'sini g�ncelleme
    private void UpdateInventoryUI()
    {
        foreach (Transform child in inventoryContent)
        {
            Destroy(child.gameObject); // �nce eski slotlar� kald�r
        }

        foreach (var item in inventoryItems)
        {
            GameObject slot = Instantiate(inventorySlotPrefab, inventoryContent);
            Text slotText = slot.GetComponentInChildren<Text>();
            if (slotText != null)
            {
                slotText.text = $"{item.Key}: {item.Value}"; // E�yay� ve miktar�n� g�ster
            }
        }
    }
}