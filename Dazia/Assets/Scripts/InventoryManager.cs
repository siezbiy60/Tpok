using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class InventoryManager : MonoBehaviour
    {
    public GameObject inventoryPanel; // Envanter paneli
    public GameObject inventorySlotPrefab; // Envanter slotu prefabý
    public Transform inventoryContent; // Envanter içeriði (panelin içinde bir layout)
    public KeyCode toggleKey = KeyCode.I; // Envanteri açma tuþu

    private bool inventoryOpen = false; // Envanter açýk mý?
    private Dictionary<string, int> inventoryItems = new Dictionary<string, int>(); // Eþyalarý saklamak için sözlük

    private void Update()
    {
        // Envanteri açma/kapama
        if (Input.GetKeyDown(toggleKey))
        {
            inventoryOpen = !inventoryOpen;
            inventoryPanel.SetActive(inventoryOpen);
        }
    }

    // Eþyayý envantere ekleme
    public void AddItemToInventory(string itemName)
    {
        if (inventoryItems.ContainsKey(itemName))
        {
            inventoryItems[itemName]++; // Ayný eþyadan bir tane daha ekle
        }
        else
        {
            inventoryItems[itemName] = 1; // Yeni eþya ekle
        }

        UpdateInventoryUI(); // UI'yi güncelle
    }

    // Envanter UI'sini güncelleme
    private void UpdateInventoryUI()
    {
        foreach (Transform child in inventoryContent)
        {
            Destroy(child.gameObject); // Önce eski slotlarý kaldýr
        }

        foreach (var item in inventoryItems)
        {
            GameObject slot = Instantiate(inventorySlotPrefab, inventoryContent);
            Text slotText = slot.GetComponentInChildren<Text>();
            if (slotText != null)
            {
                slotText.text = $"{item.Key}: {item.Value}"; // Eþyayý ve miktarýný göster
            }
        }
    }
}