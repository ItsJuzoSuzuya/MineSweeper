using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputY : MonoBehaviour
{
    public InputField yInput;
    public void ReadYInput(string y)
    {
        if (int.Parse(y) > Playfield.h / 2)
        {
            GameObject.FindObjectOfType<SetCustomFieldSize>().customY = Playfield.h / 2;
            yInput.text = (Playfield.h / 2).ToString();
        }
        else
            GameObject.FindObjectOfType<SetCustomFieldSize>().customY = int.Parse(y);
    }
}
