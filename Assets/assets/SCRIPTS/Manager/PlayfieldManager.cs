using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayfieldManager : MonoBehaviour
{
    public int xSize;
    public int ySize;

    public bool classic;
    public bool story;

    public string difficulty;

    public static PlayfieldManager instance = null;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }
}
