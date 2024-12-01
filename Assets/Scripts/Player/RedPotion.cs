using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPotion : MonoBehaviour
{
    public float HealAmount = 10;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Player collided with RedPotion");
            collision.GetComponent<PlayerHealth>().Heal(HealAmount);
            Destroy(gameObject);
        }
        else
        {
            Debug.Log($"Collision detected with tag: {collision.tag}");
        }
    }

}

