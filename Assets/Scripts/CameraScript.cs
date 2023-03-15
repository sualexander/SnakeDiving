using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{   
    public GameObject snake;

    public float endingHeight = -180;
    public float length = 8;
    private bool hasEnded = false;
    public float waitDuration = 2;
    public float panUp = 4;
    public float scoringHeight = -170;
    public GameObject finalScore;
    public float nextWaitDuration = 2;

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
        float timer = 0;
        float oldPos = transform.position.y;
        while (timer < length)
        {
            timer += Time.deltaTime / length;
            float newPos = Mathf.Lerp(oldPos, endingHeight, timer/length);
            transform.position = new Vector3(transform.position.x, newPos, transform.position.z);
            yield return null;
        }

        yield return new WaitForSeconds(waitDuration);
        timer = 0;
        oldPos = transform.position.y;

        while (timer < panUp)
        {
            timer += Time.deltaTime / panUp;
            float newPos = Mathf.Lerp(oldPos, scoringHeight, timer/panUp);
            transform.position = new Vector3(transform.position.x, newPos, transform.position.z);
            yield return null;
        }

        yield return new WaitForSeconds(nextWaitDuration);

        finalScore.SetActive(false);
    }
}
