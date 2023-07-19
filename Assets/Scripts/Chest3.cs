using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Chest3 : MonoBehaviour
{
    [SerializeField] private TMP_Text dialogueDis;
    [SerializeField] private string[] sentences;
    private int index;
    [SerializeField]
    private float typingSpeed;

    private bool next = false;

    [SerializeField] private Player player;

    private void Start()
    {
        StartCoroutine(Type());
    }

    private void Update()
    {
        if (dialogueDis.text == sentences[index])
        {
            next = true;
            if (next && Input.GetMouseButtonDown(0))
            {
                NextSentence();
            }
        }

        if (index + 1 == 6)
        {
            player.part2begins = true; 
        }
    }

    IEnumerator Type ()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            dialogueDis.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    private void NextSentence ()
    {
        next = false;
        if (index < sentences.Length - 1)
        {
            index++;
            dialogueDis.text = "";
            StartCoroutine(Type());
        } else
        {
            dialogueDis.text = "";
            next = false;
        }
    }
}
