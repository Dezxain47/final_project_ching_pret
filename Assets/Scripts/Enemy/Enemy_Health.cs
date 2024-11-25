using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Enemy_Health : MonoBehaviour
{

    [SerializeField] private float maxhealth = 10;
    private float health;

   // [SerializeField] private GameObject BloodEffect;
    [SerializeField] private GameObject Coins;
    [SerializeField] private GameObject DamageText;
    [SerializeField] private bool IsActived = false;


    // ******************** Flash Stuff*********************
    [SerializeField] private Material flashMaterial;
    [SerializeField] private float duration; 
    private SpriteRenderer spriteRenderer;
    private Material originalMaterial;
    private Coroutine flashRoutine;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalMaterial = spriteRenderer.material;
    }
    private void OnEnable()
    {
        health = maxhealth;
        IsActived = true; 
       
        spriteRenderer.material = originalMaterial;
    }


    void Update()
    {
        if (!IsActived) return;

        if (health <= 0)
        {
            if (Coins != null)
            {
               //   Instantiate(Coins, transform.position, Quaternion.identity);
                ObjectPoolingManager.instance.spawnGameObject(Coins, transform.position, Quaternion.identity);
            }
            GameManager.Instance.NumberOfKills++;
            IsActived = false;
            ObjectPoolingManager.instance.ReturnObjectToPool(gameObject);
            //   Destroy(gameObject);

        }

    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if(GetComponent<Enemy_Movement>()!=null)
        GetComponent<Enemy_Movement>().NockBackTime = .2f;

        AudioManager.instance.PlaySound("Enemy_Hurt");
        if (DamageText != null)
        {
            GameObject Text = Instantiate(DamageText, transform.position, Quaternion.identity);

            Text.GetComponent<TMP_Text>().text = damage.ToString();
        }
        if(flashMaterial!=null)
        Flash();
    }

    public void Flash()
    {
        if (flashRoutine != null)
        {
            StopCoroutine(flashRoutine);
        }
        flashRoutine = StartCoroutine(FlashRoutine());
    }

    private IEnumerator FlashRoutine()
    {
      
        spriteRenderer.material = flashMaterial;
        yield return new WaitForSeconds(duration);
        spriteRenderer.material = originalMaterial;
        flashRoutine = null;
    }
}
