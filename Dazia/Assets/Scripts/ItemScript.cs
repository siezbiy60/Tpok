using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    public string itemName; // E�yan�n ad�

    public enum ItemType { Food, Drink }
    public ItemType itemType; // E�yalar�n t�r� (yiyecek veya i�ecek)
    public float amount; // E�yan�n art�raca�� miktar

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player")) // Oyuncu ile etkile�im
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
                    Destroy(gameObject); // E�yay� sahneden kald�r
                }
            }
        }
    }
}