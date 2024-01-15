using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NPCDialogue : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public string[] lines;
    public string correctDialogue;
    public string wrongDialogue;
    public float textSpeed;

    public bool cooldown = false;

    public TextMeshProUGUI happyPeopleScoreText;
    private int happyAmount;

    public int choiceLine;
    public GameObject buttons;
    public GameObject correctOption;
    public GameObject wrongOption;

    private int index;
    private bool playerIsClose;

    private void Start()
    {
        happyAmount = 0;
        happyPeopleScoreText.text = ": " + happyAmount;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && playerIsClose && cooldown == false)
        {
            if (dialoguePanel.activeInHierarchy)
            {
                ZeroText();
            }
            else
            {
                dialoguePanel.SetActive(true);
                StartCoroutine(Typing());
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (dialogueText.text == lines[index])
            {
                NextLine();
            }
        }
    }

    public void ZeroText()
    {
        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
    }

    IEnumerator Typing()
    {
        foreach(char letter in lines[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(textSpeed);
        }

        if (index == choiceLine)
        {
            buttons.SetActive(true);
        }
        else
        {
            lines[choiceLine + 1] = "";
        }
    }   

    public void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            ZeroText();
        }
    }

    public void CorrectChoice()
    {
        dialogueText.text = "";
        buttons.SetActive(false);
        index = choiceLine + 1;
        lines[index] = correctDialogue;
        StartCoroutine(Typing());
        happyAmount++;
        happyPeopleScoreText.text = ": " + happyAmount;

        StartCoroutine(initiateCooldown(10f));
    }

    public void WrongChoice()
    {
        buttons.SetActive(false);
        dialogueText.text = "";
        index = choiceLine + 1;
        lines[index] = wrongDialogue;
        StartCoroutine(Typing());
    }

    //checks if player collides with npc
    //if thats true it will turn playerIsClose to true
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = true;
        }
    }

    //checks if player does not collides with npc
    //if thats true it will turn playerIsClose to false and removes the panel
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
            ZeroText();
        }
    }

    IEnumerator initiateCooldown(float seconds)
    {
        //turn the cooldown on
        cooldown = true;
        //wait a few seconds
        yield return new WaitForSeconds(15f);
        //turn the cooldown off
        cooldown = false;
    }
}
