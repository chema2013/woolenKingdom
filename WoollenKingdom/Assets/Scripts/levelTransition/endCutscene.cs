using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endCutscene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(cutscene());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator cutscene()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started cutscene : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(59);

        //After we have waited 5 seconds print the time again.
        Debug.Log("finished level : " + Time.time);
        SceneManager.LoadScene("Intro");
    }
}
