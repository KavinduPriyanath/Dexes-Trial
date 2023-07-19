using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FakePlayer : MonoBehaviour
{
    [SerializeField] private int boneCount;
    public int chestsOpened;

    [SerializeField] private GameObject chests;

    [SerializeField] private TMP_Text objective;

    [SerializeField] private GameObject secondDialogue;
    [SerializeField] private GameObject thirdDialogue;
    [SerializeField] private GameObject fourthDialogue;
    [SerializeField] private GameObject finalDialogue;

    private bool firstBoneInstruction;
    private bool diceUnlocked;
    public bool thirdDialogueOver;
    public bool fourthDialogueOver;

    public bool chestContact;
    private bool dialogue3Occured = false;

    public bool finishedDrumstickCollection;

    private bool attackModeOn;

    [SerializeField] private Target FinalEnemyW1;
    public bool levelEnd;

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
        levelEnd = false;
    }

    private void Update()
    {
        if (thirdDialogueOver)
        {
            objective.text = "Find drumsticks (" + boneCount + "/3)";
        }

        if (fourthDialogueOver)
        {
            objective.text = "Search and Open chests (" + chestsOpened + "/3)";
        }

        if (finishedDrumstickCollection)
        {
            fourthDialogue.SetActive(true);
        }

        if (attackModeOn)
        {
            //Activate the Shooting Script
        }

        if (FinalEnemyW1.health <= 0)
        {
            finalDialogue.SetActive(true);
            levelEnd = true;
        }

        if (chestContact == true && Input.GetKeyDown(KeyCode.F))
        {
            chestsOpened++;
            Debug.Log("One chest encountered...");
            //Destroy()
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
                    thirdDialogue.SetActive(true);
                    dialogue3Occured = true;
                }
            }
        }

        private void OnCollisionStay(Collision collision)
        {
            if (collision.gameObject.CompareTag("Chest"))
            {
                chestContact = true;
            }
        }

        private void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject.CompareTag("Chest"))
            {
                chestContact = false;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("2ndDialogue"))
            {
                secondDialogue.SetActive(true);
            }
        }

}
