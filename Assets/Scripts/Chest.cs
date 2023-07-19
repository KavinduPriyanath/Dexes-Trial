using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    private Player playerScript;

    [SerializeField] private Animator animator;

    private void Awake()
    {
        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Start()
    {
        playerScript = player.GetComponent<Player>();
    }

    private void Update()
    {
        if (playerScript.chestsOpened == 3)
        {
            animator.SetBool("Chest1Open", true);
        }

        /*
        if (playerScript.chestContact == true && Input.GetKeyDown(KeyCode.F))
        {
            Destroy(gameObject);  
        }*/
    }
}
