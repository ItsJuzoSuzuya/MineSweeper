using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("GAME STATE")]
    public bool gameStarted = false;
    public bool gameFinished = false;

    [Header("UI")]
    public float levelTime;
    public TextMeshProUGUI levelTimeText;
    [Space(10)]
    public GameObject EndScreen;
    public GameObject WinScreen;
    public GameObject LooseScreen;
    [Space(10)]
    public GameObject transition;

    //public float timeLeft = 10f;
    //public float maxTime = 10f;
    //public Slider timeSlider;

    [Header("Sound")]
    public AudioClip uncoverSound;
    public AudioClip explosionSound;
    public AudioClip flagSound;


    [Header("TILE-TEXTURES")]
    //Different Textures
    public Sprite[] emptyTextures;
    public Sprite mineTexture;
    public Sprite coveredTexture;
    public Sprite flagTexture;

    [Header("TILE-LIST")]
    public List<Element> startMines = new List<Element>();
    public List<Element> normalTiles = new List<Element>();
    public List<Element> uncoveredTiles = new List<Element>();

    /*[Header("Difficulty")]
    public string difficulty;*/

    private void Update()
    {
        //LevelTime();
        /*timeLeft -= 1 * Time.deltaTime;
        if (timeLeft <= 0)
            RestartLevel();

        timeSlider.value = CalculateTime();*/
    }

    /*float CalculateTime()
    {
        return timeLeft / maxTime;
    }*/

    /*public void LevelTime()
    {
        if(gameStarted)
        {
            levelTime += Time.deltaTime;
            levelTimeText.text = levelTime.ToString("0:00");
        }
    }*/

    //BUTTON FUNCTIONS
    public void RestartLevel()
    {
        StartCoroutine(RestartDelay());
    }

    IEnumerator RestartDelay()
    {
        transition.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        if(SceneManager.GetActiveScene().buildIndex == SceneManager.GetSceneByBuildIndex(2).buildIndex)
            SceneManager.LoadScene(2);
        else if (SceneManager.GetActiveScene().buildIndex == SceneManager.GetSceneByBuildIndex(1).buildIndex)
            SceneManager.LoadScene(1);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void WinMenu(bool win)
    {
        gameFinished = true;
        gameStarted = false;
        EndScreen.SetActive(true);
        if(win) // VICTORY
        {
            WinScreen.SetActive(true);
            LooseScreen.SetActive(false);
            FindObjectOfType<MiniMovement>().canWalk = false;
        } else{ // LOOSE
            WinScreen.SetActive(false);
            LooseScreen.SetActive(true);
            RestartLevel();
            FindObjectOfType<MiniMovement>().canWalk = false;
        }
    }
}
