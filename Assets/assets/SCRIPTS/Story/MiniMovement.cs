using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMovement : MonoBehaviour
{
    public int movementSpeed;
    public Transform player;
    public LayerMask wallLayer;
    public bool canWalk;

    public int _leftBoundary;
    public int _rightBoundary;
    public int _topBoundary;
    public int _botBoundary;

    public void Start()
    {
        _leftBoundary = 0;
        _rightBoundary = FindObjectOfType<PlayfieldManager>().xSize * 2 - 2;
        _botBoundary = 0;
        _topBoundary = FindObjectOfType<PlayfieldManager>().ySize * 2 - 2;
    }
    void FixedUpdate()
    {
        if (canWalk)
        {
            if (Input.GetKey(KeyCode.LeftShift))
                player.position += new Vector3(2 * Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime, 2 * Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime, 0);
            else
                player.position += new Vector3(Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime, Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime, 0);
        }
        if (transform.position.x >= _rightBoundary)
            transform.position = new Vector2(_rightBoundary, transform.position.y);
        else if (transform.position.x <= _leftBoundary)
            transform.position = new Vector2(_leftBoundary, transform.position.y);
        if (transform.position.y >= _topBoundary)
            transform.position = new Vector2(transform.position.x, _topBoundary);
        else if (transform.position.y <= _botBoundary)
            transform.position = new Vector2(transform.position.x, _botBoundary);
    }
}
