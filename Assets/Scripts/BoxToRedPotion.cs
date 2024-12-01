using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxToRedPotion : MonoBehaviour
{
    public GameObject redPotionPrefab; // Reference to RedPotion Prefab

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ��Ǩ�ͺ����繡�ê��Ѻ Player
        if (collision.CompareTag("Player"))
        {
            // ����¹���ͧ�� RedPotion
            if (redPotionPrefab != null)
            {
                // Instantiate RedPotion �����˹����ǡѺ���ͧ
                Instantiate(redPotionPrefab, transform.position, Quaternion.identity);

                // ����¡��ͧ��ѧ�ҡ�������¹�� RedPotion
                Destroy(gameObject);
            }
        }
    }
}
