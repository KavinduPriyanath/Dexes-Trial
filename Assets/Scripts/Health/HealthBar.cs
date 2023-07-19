using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image healthBar;

    public float currentHealth;
    private float maxHealth = 100f;

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject secondaryCam;
    [SerializeField] private GameObject retryMenu;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.fillAmount = currentHealth / maxHealth;

    }

    private void FixedUpdate()
    {
        healthBar.fillAmount = currentHealth / maxHealth;

        if (currentHealth <= 0)
        {
            Cursor.lockState = CursorLockMode.None;
            player.SetActive(false);
            secondaryCam.SetActive(true);
            retryMenu.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            int bulletDmg = other.gameObject.GetComponent<Bullet>().damage;
            currentHealth -= bulletDmg;
            Destroy(other.gameObject);
        }
    }
}
