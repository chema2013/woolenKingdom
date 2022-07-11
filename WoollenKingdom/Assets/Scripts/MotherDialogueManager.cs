using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MotherDialogueManager : MonoBehaviour
{
    int nextDialogue = DialogueBehaviour.nextText;

    public GameObject canvas;

    public DialogueBehaviour introDialogue, afterPlayerTriesToFix1Dialogue, afterPlayerFixesDialogue;

    public CompleteNpc minigame;

    public GameObject camera;

    public GameObject player;
    void Start()
    {
        minigame.enabled = false;
        introDialogue.enabled = true;
        afterPlayerTriesToFix1Dialogue.enabled = false;
        afterPlayerFixesDialogue.enabled = false;
        nextDialogue = 0;
        Debug.Log("dialogue index" + DialogueBehaviour.nextText);
    }

    void Update()
    {
        if(DialogueBehaviour.nextText == 1)
        {
            //if player has entered close up view to fix mother
            // set afterPlayerTriesToFix1Dialogue to true

            introDialogue.enabled = false;
            afterPlayerTriesToFix1Dialogue.enabled = true;
            afterPlayerFixesDialogue.enabled = false;
        }
        if(DialogueBehaviour.nextText == 2)
        {
            //if player enters close up view to fix heart/ has fixed heart
            // set afterfix dialogue to true

            canvas.SetActive(false);
            minigame.enabled = true;
            introDialogue.enabled = false;
            afterPlayerTriesToFix1Dialogue.enabled = false;
            afterPlayerFixesDialogue.enabled = false;
        }
        if(DialogueBehaviour.nextText == 3)
        {
            //if player enters close up view to fix heart/ has fixed heart
            // set afterfix dialogue to true

            camera.GetComponent<Camera>().orthographicSize = 3.66f;
            player.GetComponent<SpriteRenderer>().enabled = true;
            CompleteNpc.minigame = false;
            canvas.SetActive(true);
            minigame.enabled = false;
            introDialogue.enabled = false;
            afterPlayerTriesToFix1Dialogue.enabled = false;
            afterPlayerFixesDialogue.enabled = true;
        }

        if(DialogueBehaviour.nextText == 4)
        {
            SceneManager.LoadScene("Ending");
            Debug.Log("finished 3rd level");
        }

    }
}
