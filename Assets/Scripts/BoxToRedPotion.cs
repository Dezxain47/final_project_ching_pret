using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxToRedPotion : MonoBehaviour
{
    public GameObject redPotionPrefab; // Reference to RedPotion Prefab

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ตรวจสอบว่าเป็นการชนกับ Player
        if (collision.CompareTag("Player"))
        {
            // เปลี่ยนกล่องเป็น RedPotion
            if (redPotionPrefab != null)
            {
                // Instantiate RedPotion ที่ตำแหน่งเดียวกับกล่อง
                Instantiate(redPotionPrefab, transform.position, Quaternion.identity);

                // ทำลายกล่องหลังจากที่เปลี่ยนเป็น RedPotion
                Destroy(gameObject);
            }
        }
    }
}
