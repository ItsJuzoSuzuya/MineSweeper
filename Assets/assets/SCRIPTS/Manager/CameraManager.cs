using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{

    public Vector2 lastTilePos;
    public Vector2 centre;

    // Start is called before the first frame update
    void Start()
    {
        centre = new Vector2(FindObjectOfType<PlayfieldManager>().xSize - 1, FindObjectOfType<PlayfieldManager>().ySize - 1);

        Vector3 camPos = centre;
        camPos.z = -10;
        transform.position = camPos;    
    }
}
