using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject MainManuPanel;
    public GameObject PlayPanel;
    public GameObject SettingsPanel;
    public GameObject StoryPanel;

    void Start()
    {
        openMainMenuPanel();
    }


    //BUTTON CONTROL
    public void LoadStoryMenu()
    {
        SceneManager.LoadScene(3);
    }

    public void Quit()
    {
        Application.Quit();
    }

    //PANEL CONTROLL
    public void openMainMenuPanel()
    {
        MainManuPanel.SetActive(true);

        PlayPanel.SetActive(false);
        SettingsPanel.SetActive(false);
        StoryPanel.SetActive(false);

        FindObjectOfType<PlayfieldManager>().classic = false;
        FindObjectOfType<PlayfieldManager>().story = false;
    }

    public void openStoryPanel()
    {
        StoryPanel.SetActive(true);

        MainManuPanel.SetActive(false);
        SettingsPanel.SetActive(false);

        FindObjectOfType<PlayfieldManager>().story = true;
    }
    
    public void openPlayPanel()
    {
        PlayPanel.SetActive(true);

        MainManuPanel.SetActive(false);
        SettingsPanel.SetActive(false);

        FindObjectOfType<PlayfieldManager>().classic = true;

    }

    public void openSettingsPanel()
    {
        SettingsPanel.SetActive(true);

        MainManuPanel.SetActive(false);
        PlayPanel.SetActive(false);
    }
}
