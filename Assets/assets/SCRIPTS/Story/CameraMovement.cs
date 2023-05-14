using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{ 
    void Update()
    {
        this.gameObject.transform.position = FindObjectOfType<Player>().transform.position - new Vector3(0,0,20);   
    }
}
