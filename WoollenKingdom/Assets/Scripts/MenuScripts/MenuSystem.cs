using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSystem : MonoBehaviour
{
    public GameObject Credit;

    void Start()
    {
        Credit.SetActive(false);
    }

    void Update()
    {
        CreditEscape();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Credits()
    {
        Credit.SetActive(true);
    }

    public void CreditEscape()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Credit.SetActive(false);
        }
    }
}

