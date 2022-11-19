using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Canvas main;
    [SerializeField] private Canvas settings;
    public void OnClickSettings()
    {
        main.enabled = false;
        settings.enabled = true;
    }

    public void OnClickBack()
    {
        settings.enabled = false;
        main.enabled = true;
    }

    public void OnClickPlay()
    {
        SceneManager.LoadScene("Game");
    }
}
