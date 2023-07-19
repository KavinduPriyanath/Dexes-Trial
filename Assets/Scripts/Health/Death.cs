using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject secondaryCam;
    [SerializeField] private GameObject retryMenu;


    private void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Cursor.lockState = CursorLockMode.None;
            player.SetActive(false);
            secondaryCam.SetActive(true);
            retryMenu.SetActive(true);
        }
    }
}
