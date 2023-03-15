using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    void Update()
    {
        transform.Translate(Vector2.up * Game.gravitySpeed * Time.deltaTime);
    }
}
