using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public int movementSpeed;
    public LayerMask wallLayer;
    public bool canWalk;

    void FixedUpdate()
    {
        if (canWalk)
        {
            if (Input.GetKey(KeyCode.LeftShift))
               this.transform.position += new Vector3(2 * Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime, 2 * Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime, 0);
            else
               this.transform.position += new Vector3(Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime, Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime, 0);
        }
    }
}
