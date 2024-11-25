using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBullet : MonoBehaviour
{
    [SerializeField] float speed = 5.0f, damage = 5;
   [HideInInspector] public Transform EnemyPosition;
    Vector3 direction;
    [SerializeField] private bool IsActived = true;


    private void OnEnable()
    {
        IsActived = true;
        StartCoroutine(Reset());
        Invoke ("CalculateDirection", .01f);    
    }
    private void CalculateDirection()
    {          if(EnemyPosition != null) 
        direction = (EnemyPosition.position - transform.position).normalized;        
    }
    void Update()
    {      
       
       if(IsActived)
        transform.position += (direction) * speed * Time.deltaTime;

     
    }
    private IEnumerator Reset()
    {
            yield return new WaitForSeconds(3);
        if (IsActived)
        {
            Debug.Log("zedaedaeazea azeaea aeae ");
            ObjectPoolingManager.instance.ReturnObjectToPool(this.gameObject);
        }
    }


    private void Destroy()
    {if(IsActived)
        ObjectPoolingManager.instance.ReturnObjectToPool(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {

            collision.gameObject.GetComponent<Enemy_Health>().TakeDamage(damage);
            Destroy();
            IsActived = false;
        }

        if (collision.tag == "Wall")
        {
            Destroy();
            IsActived = false;
        }
       
    }

}