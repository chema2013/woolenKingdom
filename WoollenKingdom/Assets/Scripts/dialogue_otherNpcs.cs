using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class dialogue_otherNpcs : MonoBehaviour
{
    
    public GameObject textBox;
    public TMP_Text dialogueText;
    public string[] dialogue;
    int index;
    float wordSpeed = 0.01f;
    bool playerIsClose;
    public GameObject buttonPrompt;

    void Start()
    {
        ResetText();
    }

    void Update()
    {
        if (playerIsClose && Input.GetKeyDown(KeyCode.E))
        {
            if (textBox.activeInHierarchy)
            {
                ResetText();
            }
            else
            {
                buttonPrompt.gameObject.SetActive(false);
                textBox.SetActive(true);
                StartCoroutine(Typing());
            }
        }

        if(dialogueText.text == dialogue[index] && Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return)) // if text has finished typing
        {
            NextLine();
        }
        /*else if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return)) // the way typing works with the current set up does not allow for text skipping. it simply restarts typing the same letters in an element within itself
        {
            dialogueText.text = dialogue[index]; // set text to finish
        }*/
    }

    IEnumerator Typing()
    {
        //  cycle through dialogue text, going letter by letter
        foreach(char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }

    void NextLine()
    {
        if(index < dialogue.Length - 1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            ResetText();

        }
    }

    void ResetText()
    {
        dialogueText.text = "";
        index = 0;
        textBox.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            playerIsClose = true;
            buttonPrompt.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerIsClose = false;
            buttonPrompt.gameObject.SetActive(false);
            ResetText();
        }
    }
}
