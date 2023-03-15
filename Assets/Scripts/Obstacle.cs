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

    public float fadeDuration = 1;

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
            StartCoroutine(FadeOut());
            
            // if (isLauncher)
            // {
            //     StartCoroutine(Launch());
            // }
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

    private IEnumerator FadeOut()
    {
        float timer = 0;
        float alpha = 1;

        var sprite = transform.GetComponent<SpriteRenderer>().material;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime / fadeDuration;
            alpha = 1-(timer/fadeDuration);
            sprite.color = new Color(1,1,1,alpha);
            yield return null;
        }

        Destroy(this);
    }
}
