using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputX : MonoBehaviour
{
    public InputField xInput;
    public void ReadXInput(string x)
    {
        if (int.Parse(x) > Playfield.w / 2)
        {
            GameObject.FindObjectOfType<SetCustomFieldSize>().customX = Playfield.w / 2;
            xInput.text = (Playfield.w / 2).ToString();
        }
        else
            GameObject.FindObjectOfType<SetCustomFieldSize>().customX = int.Parse(x);
    }
}
