using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int score = 20;
    public float force = 20;
    public float length = 0.8f;
    public bool isLauncher = false;

    private bool hasCollided = false;

    Transform hook;

    void Start()
    {
        hook = GameObject.Find("Snake").transform.GetChild(0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!hasCollided)
        {
            hasCollided = true;
            Game.score += score;
            print(Game.score);
            
            if (isLauncher)
            {
                StartCoroutine(Launch());
            }
        }
    }

    private IEnumerator Launch()
    {
        float timer = 0;

        while (timer < length)
        {
            timer += Time.deltaTime / length;
            hook.transform.Translate(Vector2.up * Time.deltaTime * force, Space.World);
            yield return null;
        }
    }
}
