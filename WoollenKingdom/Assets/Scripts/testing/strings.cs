using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class strings : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
          int source = Player.wool;

          Player.wool += 1;

          Debug.Log(Player.wool);

          Destroy(gameObject);
        }
    }
}
