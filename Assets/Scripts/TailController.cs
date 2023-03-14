using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailController : MonoBehaviour
{

public Rigidbody2D tail;
    private void Update() {
    if (Input.GetKey(KeyCode.LeftArrow))
        print("left");
        tail.AddForce(Vector3.left);
    if (Input.GetKey(KeyCode.RightArrow))
        tail.AddForce(Vector3.right);
    if (Input.GetKey(KeyCode.UpArrow))
        tail.AddForce(Vector3.up);
    if (Input.GetKey(KeyCode.DownArrow))
        tail.AddForce(Vector3.down);
    }
}
