using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetW2 : MonoBehaviour
{
    public float health = 100f;

    [SerializeField] private float maxHealth;

    [SerializeField] private Image healthBar;

    [SerializeField] private float damage;

    private void Start()
    {
        healthBar.fillAmount = health;
        

    }

    /*
    public void TakeDamage (float amount)
    {
        health -= amount;
        healthBar.fillAmount = health / maxHealth;
        if (health <= 0f)
        {
            Die();
        }
    }*/

    void Die()
    {
        Destroy(gameObject.transform.parent.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            health -= damage;
            healthBar.fillAmount = health / maxHealth;

            if (health <= 0f)
            {
                Die();
            }
        }
    }
}
