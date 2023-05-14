using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundPanel : MonoBehaviour
{
    SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = Camera.main.GetComponent<CameraManager>().centre;
        sprite = GetComponent<SpriteRenderer>();
        sprite.transform.localScale = new Vector3(0.4f, 0.4f, 0);
        sprite.size = new Vector2((PlayfieldManager.instance.xSize/0.4f) * 2 + 4, (PlayfieldManager.instance.ySize/0.4f) * 2 + 4);
    }
}
