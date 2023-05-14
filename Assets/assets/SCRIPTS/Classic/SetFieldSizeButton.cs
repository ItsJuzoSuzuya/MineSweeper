using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetFieldSizeButton : MonoBehaviour
{
    public int x, y;
    public void LoadLevel(string difficulty)
    {
        FindObjectOfType<PlayfieldManager>().xSize = x;
        FindObjectOfType<PlayfieldManager>().ySize = y;
        PlayfieldManager.instance.difficulty = difficulty;
        Debug.Log(PlayfieldManager.instance.difficulty);
        SceneManager.LoadScene(1);
    }
}


