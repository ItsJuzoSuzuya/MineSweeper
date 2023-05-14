using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour
{

    public int maxX;
    public int maxY;

    public GameObject tile;
    public GameObject player;

    public Transform tileParent;
    public Transform HealthBar;

    public bool botLeft;
    public bool botRight;
    public bool topLeft;
    public bool topRight;

    public Vector3 startPosition;

    void Awake()
    {
        botLeft = Random.value <= 0.25;
        if(!botLeft)
            botRight = Random.value <= 0.33;
        if (!botLeft && !botRight)
            topRight = Random.value <= 0.5;
        if (!botLeft && !botRight && !topRight)
            topLeft = true;

        maxX = FindObjectOfType<PlayfieldManager>().xSize;
        maxY = FindObjectOfType<PlayfieldManager>().ySize;

        for (int i = 0; i < maxX; i++)
        {
            for (int g = 0; g < maxY; g++)
            {
                GameObject go = Instantiate(tile, new Vector2(i * 2, g * 2), Quaternion.identity, tileParent) as GameObject;
            }
        }
        if (FindObjectOfType<PlayfieldManager>().story)
        {
            HealthBar.position = new Vector2(maxX - 1, maxY * 2 + 1);
            if (botLeft)
            {
                startPosition = new Vector2(0, 0);
                GameObject clone = Instantiate(player, new Vector2(0, 0), Quaternion.identity, tileParent) as GameObject;
            }
            else if (botRight)
            {
                startPosition = new Vector2(maxX * 2 - 2, 0);
                GameObject clone = Instantiate(player, new Vector2(maxX * 2 - 2, 0), Quaternion.identity, tileParent) as GameObject;
            }
            else if (topRight) 
            {
                startPosition = new Vector2(maxX * 2 - 2, maxY * 2 - 2);
                GameObject clone = Instantiate(player, new Vector2(maxX * 2 - 2, maxY * 2 - 2), Quaternion.identity, tileParent) as GameObject;
            }
            else if (topLeft)
            {
                startPosition = new Vector2(0, maxY * 2 - 2);
                GameObject clone = Instantiate(player, new Vector2(0, maxX * 2 - 2), Quaternion.identity, tileParent) as GameObject;
            }
        }

        
    }
}