using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private GameObject secondWave;
    [SerializeField] private GameObject thirdWave;      //2 twos
    [SerializeField] private GameObject fourthWave;     //2 threes
    [SerializeField] private GameObject fifthWave;      //1 four
    [SerializeField] private GameObject sixthWave;      //1 five
    [SerializeField] private GameObject seventhWave;    //1 six

    private bool second;
    private bool third;
    private bool fourth;
    private bool fifth;
    private bool sixth;

    [SerializeField] private GameObject victoryMenu;

    private void Start()
    {
        second = false;
        third = false;
        fourth = false;
        fifth = false;
        sixth = false;
    }

    private void Update()
    {
        if (GameObject.Find("EnemyWave1") == null && second == false)
        {
            secondWave.SetActive(true);
            second = true;
        }

        if (GameObject.Find("EnemyWave2") == null && third == false && second == true)
        {
            thirdWave.SetActive(true);
            third = true;
        }

        if (GameObject.Find("EnemyWave3") == null && third == true)
        {
            victoryMenu.SetActive(true);
        }

        /*

        if (GameObject.Find("EnemyWave4") == null && fourth == false)
        {
            fifthWave.SetActive(true);
            fourth = true;
        }

        if (GameObject.Find("EnemyWave5") == null && fifth == false)
        {
            sixthWave.SetActive(true);
            fifth = true;
        }

        if (GameObject.Find("EnemyWave6") == null && sixth == false)
        {
            seventhWave.SetActive(true);
            sixth = true;
        }*/

        /*
        if (GameObject.Find("EnemyWave7") == null)
        {
            secondWave.SetActive(true);
        }*/
    }
}
