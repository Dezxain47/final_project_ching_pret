using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    float nextFire;
    public int bulletNumber =2;
    [SerializeField] private float fireRate;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float Distance;
    private Transform closestEnemyPostion;

    void Update()
    {
        FindClosestEnemy();
        Fire();
    }




    void Fire()
    {

        if (Time.time > nextFire && closestEnemyPostion != null&& bulletNumber>0)
        {
            for (int i = 0; i < bulletNumber; i++)
            {
                StartCoroutine(ShootBullet(i*.1f));
            }
            
            nextFire = Time.time + fireRate;

        }

    }





    void FindClosestEnemy()
    {
        float distanceToClosestEnemy = Mathf.Infinity;
        Enemy_Health closestEnemy = null;
        Enemy_Health[] allEnemies = GameObject.FindObjectsOfType<Enemy_Health>();

        foreach (Enemy_Health currentEnemy in allEnemies)
        {
            float distanceToEnemy = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;
            if (distanceToEnemy < distanceToClosestEnemy && distanceToEnemy < Distance * 10)
            {
                distanceToClosestEnemy = distanceToEnemy;
                closestEnemy = currentEnemy;

                closestEnemyPostion = closestEnemy.transform;

            }
        }

        if (closestEnemy != null)
        {
            Debug.DrawLine(this.transform.position, closestEnemy.transform.position);


        }
    }


    IEnumerator ShootBullet(float delay)
    {
        yield return new WaitForSeconds(delay);

        AudioManager.instance.PlaySound("Spell");
        //  GameObject Bullett = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        GameObject Bullett = ObjectPoolingManager.instance.spawnGameObject(bulletPrefab,transform.position,Quaternion.identity);
       Bullett.GetComponent<TurretBullet>().EnemyPosition = closestEnemyPostion;
    }
}

    