using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private void Start()
    {
        LoadPlayer();
    }
    public void SavePlayer()
    {
        Debug.Log("Saving player");
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        Debug.Log("Loading player");
        PlayerData data = SaveSystem.LoadPlayer();

        Vector3 playerPosition;
        playerPosition.x = data.playerPosition[0];
        playerPosition.y = data.playerPosition[1];
        playerPosition.z = data.playerPosition[2];

        this.transform.position = playerPosition;
    }
}
