using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetCustomFieldSize : MonoBehaviour
{
    public int customX, customY;

    public GameObject menu;
    public void LoadCustom()
    {
        FindObjectOfType<PlayfieldManager>().xSize = customX;
        FindObjectOfType<PlayfieldManager>().ySize = customY;


        if (customX <= Playfield.w / 2 && customY <= Playfield.h / 2)
        {
            if (SceneManager.GetActiveScene().buildIndex == SceneManager.GetSceneByBuildIndex(0).buildIndex)
            {
                Debug.Log(SceneManager.GetActiveScene().buildIndex);
                Debug.Log(SceneManager.GetSceneAt(0).buildIndex);
                SceneManager.LoadScene(1);
                FindObjectOfType<PlayfieldManager>().classic = true;
            }
            else
            {
                SceneManager.LoadScene(2);
                FindObjectOfType<PlayfieldManager>().story = true;
            }
        }
    }
}
