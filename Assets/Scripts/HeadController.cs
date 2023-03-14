using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadController : MonoBehaviour
{

public Rigidbody2D head;
    private void Update() {
    if (Input.GetKey(KeyCode.A))
        head.AddForce(Vector3.left);
    if (Input.GetKey(KeyCode.D))
        head.AddForce(Vector3.right);
    if (Input.GetKey(KeyCode.W))
        head.AddForce(Vector3.up);
    if (Input.GetKey(KeyCode.S))
        head.AddForce(Vector3.down);
    }
}
