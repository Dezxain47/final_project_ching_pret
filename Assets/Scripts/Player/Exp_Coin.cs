using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exp_Coin : MonoBehaviour
{

    [SerializeField] private float speed=3;
    [SerializeField] private int Exp=20;
    [SerializeField] private float Range = 5;
    private Transform player;


  
    void Start()
    {

        player = GameObject.FindWithTag("Player").GetComponent<Transform>();

    }

    // Update is called once per frame-
    void Update()
    {

     
 
        float distToPlayer = Vector2.Distance(transform.position, player.position);
     
        if (distToPlayer <= Range)
        {
          //  UpgradeSpawn.Instance.AddExp(5);

            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
           UpgradeManager.Instace.AddExp(Exp);  
            ObjectPoolingManager.instance.ReturnObjectToPool(gameObject);

        }
    }
}
