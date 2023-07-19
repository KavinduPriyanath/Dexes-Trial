using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Active2 : MonoBehaviour
{
    [SerializeField] private bool activeSecond;
    [SerializeField] private GameObject secondDialogue;

    private void Start()
    {
        activeSecond = false;
    }

    private void Update()
    {
        if (activeSecond == true)
        {
            secondDialogue.SetActive(true);
        }
    }
}
