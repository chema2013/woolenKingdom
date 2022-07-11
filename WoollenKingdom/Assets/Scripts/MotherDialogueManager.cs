using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherDialogueManager : MonoBehaviour
{
    int nextDialogue = DialogueBehaviour.nextText;
    public DialogueBehaviour introDialogue, afterPlayerTriesToFix1Dialogue, afterPlayerFixesDialogue;
    void Start()
    {
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

            introDialogue.enabled = false;
            afterPlayerTriesToFix1Dialogue.enabled = false;
            afterPlayerFixesDialogue.enabled = true;
        }

    }
}
