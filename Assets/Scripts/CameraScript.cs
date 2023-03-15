using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{   
    public GameObject snake;

    public float endingHeight = -180;
    private bool hasEnded = false;

    void Update()
    {
        if (!hasEnded)
        {
            Vector3 pos = transform.position;
            transform.position = new Vector3(pos.x, snake.transform.position.y, pos.z);
        }
    }

    public void StopCamera()
    {
        hasEnded = true;
        StartCoroutine(MoveCamera());
    }

    private IEnumerator MoveCamera()
    {
        print("AWDASDASD");
        float timer = 0;
        float length = 3f;

        while (timer < length)
        {
            timer += Time.deltaTime / length;
            float newPos = Mathf.Lerp(transform.position.y, endingHeight, timer/length);
            transform.position = new Vector3(transform.position.x, newPos, transform.position.z);
            yield return null;
        }
    }
}
