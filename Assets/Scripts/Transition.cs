using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{

    [SerializeField] private FakePlayer player;

    [SerializeField] private Animator animator;

    private void Update()
    {
        if (player.levelEnd == true)
        {
            StartCoroutine(ScreenClose());
        }
    }

    IEnumerator ScreenClose ()
    {
        yield return new WaitForSeconds(2f);
        animator.SetBool("Close", true);
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene("World2");
    }
}
