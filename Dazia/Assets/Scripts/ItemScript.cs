using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    public string itemName; // Eþyanýn adý

    public enum ItemType { Food, Drink }
    public ItemType itemType; // Eþyalarýn türü (yiyecek veya içecek)
    public float amount; // Eþyanýn artýracaðý miktar

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player")) // Oyuncu ile etkileþim
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                HungerAndThirst ht = FindObjectOfType<HungerAndThirst>();
                if (ht != null)
                {
                    if (itemType == ItemType.Food)
                    {
                        ht.EatFood();
                    }
                    else if (itemType == ItemType.Drink)
                    {
                        ht.Drink();
                    }
                    Destroy(gameObject); // Eþyayý sahneden kaldýr
                }
            }
        }
    }
}