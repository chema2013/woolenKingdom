using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeSprite : MonoBehaviour
{
    public GameObject unfinished;
    public GameObject complete;


    // Start is called before the first frame update
    void Start()
    {
        complete.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.gameObject.tag == "complete")
        {
            complete.SetActive(true);

            Debug.Log("fixed npc");
            unfinished.SetActive(false);
        }
    }
}
