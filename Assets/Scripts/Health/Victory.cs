using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour
{
    [SerializeField] private TMP_Text dialogueDis;
    [SerializeField] private string[] sentences;
    private int index;
    [SerializeField]
    private float typingSpeed;

    [SerializeField] private GameObject returnToMenuBtn;

    private bool next = false;

    private void Start()
    {
        StartCoroutine(Type());
    }

    private void Update()
    {
        if (dialogueDis.text == sentences[index])
        {
            next = true;
            returnToMenuBtn.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            if (next && Input.GetMouseButtonDown(0))
            {
                NextSentence();
            }
        }

        
    }

    IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            dialogueDis.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    private void NextSentence()
    {
        next = false;
        if (index < sentences.Length - 1)
        {
            index++;
            dialogueDis.text = "";
            StartCoroutine(Type());
        }
        else
        {
            dialogueDis.text = "";
            next = false;
        }
    }

    public void MainMenu ()
    {
        Application.Quit();
    }
}
