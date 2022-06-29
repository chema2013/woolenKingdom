using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CompleteNpc : MonoBehaviour
{
    bool playerIsClose;
    public GameObject buttonPrompt;

    public GameObject camera;

    public float zoomSize = 5;

    public GameObject player;

    public bool minigame = false;

    public GameObject drawingNPC;

    public GameObject drawingWorld;

    void Start()
    {
        drawingNPC.SetActive(false);
    }

    void Update()
    {
        if (playerIsClose && Input.GetKeyDown(KeyCode.E) && minigame == false)
        {
            buttonPrompt.gameObject.SetActive(false);
            camera.GetComponent<Camera>().orthographicSize = zoomSize - 4;
            player.GetComponent<SpriteRenderer>().enabled = false;
            minigame = true;
            player.GetComponent<IsoPlayerMovement>().enabled = false;
            drawingNPC.SetActive(true);
            drawingWorld.SetActive(false);

            Debug.Log(minigame);
        }
        else if(Input.GetKeyDown(KeyCode.E) && minigame == true)
        {
            minigame = false;
            camera.GetComponent<Camera>().orthographicSize = zoomSize;
            player.GetComponent<SpriteRenderer>().enabled = true;
            player.GetComponent<IsoPlayerMovement>().enabled = true;
            drawingNPC.SetActive(false);
            drawingWorld.SetActive(true);

            Debug.Log(minigame);
        }
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
        }
    }
}
