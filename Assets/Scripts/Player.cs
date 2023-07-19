using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField] private int boneCount;
    public int chestsOpened;

    [SerializeField] private GameObject chests;

    [SerializeField] private TMP_Text objective;
    [SerializeField] private TMP_Text secondaryobj;
    [SerializeField] private GameObject objIcons;

    [SerializeField] private GameObject firstDialogue;
    [SerializeField] private GameObject secondDialogue;
    [SerializeField] private GameObject thirdDialogue;
    [SerializeField] private GameObject fourthDialogue;
    //[SerializeField] private GameObject finalDialogue;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private TMP_Text chestDialogue1;
    [SerializeField] private TMP_Text chestDialogue2;

    private bool firstBoneInstruction;
    private bool diceUnlocked;
    public bool thirdDialogueOver;
    public bool fourthDialogueOver;
    public bool part2begins;

    public bool chestContact;
    private bool dialogue3Occured = false;

    public bool finishedDrumstickCollection;

    private bool attackModeOn;

    //[SerializeField] private Target FinalEnemyW1;
    //public bool levelEnd;

    [SerializeField] private GameObject chest1;
    [SerializeField] private GameObject chest2;
    [SerializeField] private GameObject chest3;
    [SerializeField] private GameObject chestOptional;

    private GameObject currentChest;


    private void Start()
    {
        boneCount = 0;
        chestsOpened = 0;
        firstBoneInstruction = false;
        diceUnlocked = false;
        thirdDialogueOver = false;
        fourthDialogueOver = false;
        chestContact = false;
        finishedDrumstickCollection = false;
        attackModeOn = false;
        //levelEnd = false;
        part2begins = false;
    }

    private void Update()
    {
        if (thirdDialogueOver)
        {
            objective.text = "Find drumsticks (" + boneCount + "/3)";
            secondaryobj.text = "- Look for anomalies";
            objIcons.SetActive(true);
        }

        if (fourthDialogueOver)
        {
            objective.text = "Search and Open chests (" + chestsOpened + "/3)";
            secondaryobj.text = "- Keep an eye out";
            objIcons.SetActive(true);
        }

        if (finishedDrumstickCollection)
        {
            fourthDialogue.SetActive(true);
        }

        if (attackModeOn)
        {
            //Activate the Shooting Script
        }

        /*
        if (FinalEnemyW1.health <= 0)
        {
            finalDialogue.SetActive(true);
            levelEnd = true;
        }*/

        if (boneCount == 1)
        {
            thirdDialogue.SetActive(false);
            dialogueText.text = "";
        }

        if (chestContact)
        {
            fourthDialogue.SetActive(false);
            dialogueText.text = "";
        }


        if (finishedDrumstickCollection)
        {
            if (chestContact == true && Input.GetKeyDown(KeyCode.F))
            {
                chestsOpened++;
                chestContact = false;
                Debug.Log("One chest encountered...");


                if (chestsOpened == 1)
                {
                    chest1.SetActive(true);
                    Destroy(currentChest.transform.parent.gameObject);
                }

                if (chestsOpened == 2)
                {
                    chest1.SetActive(false);
                    chest2.SetActive(true);
                    chestDialogue1.text = "";
                    Destroy(currentChest.transform.parent.gameObject);
                }

                if (chestsOpened == 3)
                {
                    chest2.SetActive(false);
                    chestDialogue2.text = "";
                    chest3.SetActive(true);
                }
            }
        } else
        {
            if (chestContact == true && Input.GetKeyDown(KeyCode.F))
            {
                chestOptional.SetActive(true);
                StartCoroutine(ChestUnlock());
            }

        }


        if (boneCount == 3 && !firstBoneInstruction)
        {
            //Show find chests next dialogue
            //Set active chests gameobjects
            //chests.SetActive(true);
            firstBoneInstruction = true;
            fourthDialogueOver = true;  //should be false actually
            finishedDrumstickCollection = true;
            
        }

        if (boneCount == 1)
        {
            thirdDialogue.SetActive(false);
            dialogueText.text = "";
        }

        if (chestsOpened == 3 && !diceUnlocked)
        {
            Debug.Log("Raw Dice unlocked");
            diceUnlocked = true;
            //Dialogue explaining the need of finding numbers
            //Activate numbers
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bones"))
        {
            Destroy(other.gameObject);
            boneCount++;
        }

        if (other.CompareTag("Bone Effects"))
        {
            Destroy(other.gameObject);
            Debug.Log("Entered");

            if (dialogue3Occured == false)
            {
                secondDialogue.SetActive(false);
                dialogueText.text = "";
                thirdDialogue.SetActive(true);
                GetComponent<FPSController>().enabled = false;
                Cursor.lockState = CursorLockMode.None;
                dialogue3Occured = true;
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Chest"))
        {
            chestContact = true;
            currentChest = collision.gameObject;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Chest"))
        {
            chestContact = false;
            currentChest = null;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("2ndDialogue"))
        {
            firstDialogue.SetActive(false);
            dialogueText.text = "";
            secondDialogue.SetActive(true);
        }
    }

    IEnumerator ChestUnlock ()
    {
        yield return new WaitForSeconds(2f);
        chestOptional.SetActive(false);
        dialogueText.text = "";
    }

}
