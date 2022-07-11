using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelTransition : MonoBehaviour
{

    public GameObject target;

    public int levelIndex;

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            if(levelIndex == 1)
            {
                SceneManager.LoadScene("Village");
                Debug.Log("finished 1st level");
            }
            
            if(levelIndex == 2)
            {
                SceneManager.LoadScene("CastleLevel");
                Debug.Log("finished 2nd level");
            }
        }
    }
}
