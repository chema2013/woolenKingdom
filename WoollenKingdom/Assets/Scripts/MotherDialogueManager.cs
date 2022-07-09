using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherDialogueManager : MonoBehaviour
{
    public DialogueBehaviour introDialogue, afterPlayerTriesToFix1Dialogue, afterPlayerFixesDialogue;
    void Start()
    {
        introDialogue.enabled = true;
        afterPlayerTriesToFix1Dialogue.enabled = false;
        afterPlayerFixesDialogue.enabled = false;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            //if player has entered close up view to fix mother
            // set afterPlayerTriesToFix1Dialogue to true

            introDialogue.enabled = false;
            afterPlayerTriesToFix1Dialogue.enabled = true;
            afterPlayerFixesDialogue.enabled = false;
        }
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            //if player enters close up view to fix heart/ has fixed heart
            // set afterfix dialogue to true

            introDialogue.enabled = false;
            afterPlayerTriesToFix1Dialogue.enabled = false;
            afterPlayerFixesDialogue.enabled = true;
        }

    }
}
