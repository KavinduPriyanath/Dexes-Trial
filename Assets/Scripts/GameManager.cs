using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject fakePlayer;
    [SerializeField] private GameObject enemy;

    [SerializeField] private TMP_Text objective;

    private Player playerScript;

    private void Start()
    {
        playerScript = player.GetComponent<Player>();
    }

    private void Update()
    {
        if (playerScript.part2begins == true)
        {
            player.SetActive(false);
            fakePlayer.SetActive(true);
            enemy.SetActive(true);
            objective.text = "Kill the scout";
        }
    }
}
