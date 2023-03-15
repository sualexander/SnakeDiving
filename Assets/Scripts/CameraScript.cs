using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CameraScript : MonoBehaviour
{   
    public GameObject snake;

    public AudioManager audioManager;

    public Snake snakeScript;

    public float cameraSpeed;
    public float endingHeight = -180;
    public float length = 8;
    private bool hasEnded = false;
    public float waitDuration = 2;
    public float panUp = 4;
    public float scoringHeight = -170;
    public GameObject finalScore;
    public ParticleSystem splash;
    public float nextWaitDuration = 2;

    public float maxHeight;

    public Animator sign1;
    public Animator sign2;
    public Animator sign3;

    public TMP_Text t1;
    public TMP_Text t2;
    public TMP_Text t3;

    public TMP_Text totalScore;
    public Animator finalScoreAnim;

    public bool stopped = true;
    
    private float startPos;

    public float threshold = 0.1f;
    public AudioSource windSound;

    public float cheerHeight = -109;
    public float cheerHeight2 = - 120;

    public Animator judgeBlue;
    public Animator judgeRed;

    private bool hasCheered = false;
    private bool hasCheered2 = false;

    void Start()
    {
        startPos = transform.position.y;
    }

    private float alpha = 0;
    void Update()
    {
        if (!hasEnded)
        {
            if (stopped)
            {
                float snakeVert = snake.transform.position.y;
                Vector3 pos = transform.position;
                alpha += Time.deltaTime * cameraSpeed;
                alpha = Mathf.Clamp(alpha, 0, 1);
                float newVert = Mathf.Lerp(startPos, snakeVert, alpha);
                transform.position = new Vector3(pos.x, newVert, pos.z);
                print(newVert);
                if (Mathf.Abs(transform.position.y - snakeVert) <= threshold)
                {
                    stopped = false;
                    snakeScript.gravity = 4;
                }
            }
            else
            {
                Vector3 pos = transform.position;
                float vert = Mathf.Clamp(snake.transform.position.y, -1000, maxHeight);

                //float newVert = Mathf.Lerp(transform.position.y, vert, Time.deltaTime * cameraSpeed);
                transform.position = new Vector3(pos.x, vert, pos.z);

                if (transform.position.y <= endingHeight)
                {
                    StopCamera();
                }

                if (pos.y <= cheerHeight)
                {
                    if (!hasCheered)
                    {
                        hasCheered = true;
                        judgeBlue.enabled = true;
                        judgeBlue.Play("JudgeBlue");
                        audioManager.cheer();
                    }
                }

                if (pos.y <= cheerHeight2)
                {
                    if (!hasCheered2)
                    {
                        hasCheered2 = true;
                        judgeRed.enabled = true;
                        audioManager.cheer();
                    }
                }
            }
        }
    }

    public void StopCamera()
    {
        hasEnded = true;
        StartCoroutine(MoveCamera());
        CalculateScore(); 
    }

    private IEnumerator MoveCamera()
    {
        float timer = 0;
        float oldPos = transform.position.y;

        splash.Play();
        audioManager.hitWater();
        windSound.volume = 0;

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

        audioManager.receiveScore();
        sign1.enabled = true;
        sign1.Play("Sings");
        yield return new WaitForSeconds(0.3f);
        sign2.enabled = true;
        sign2.Play("Sings");
        yield return new WaitForSeconds(0.3f);
        sign3.enabled = true;
        sign3.Play("Sings");

        yield return new WaitForSeconds(nextWaitDuration);

        finalScore.SetActive(true);
        finalScoreAnim.enabled = true;
    }

    void CalculateScore()
    {
        int score = Mathf.Clamp(Game.score + 3, 2, 10);
        int s1 = Mathf.Clamp(score + Random.Range(0,1), 1, 10);
        int s2 = Mathf.Clamp(score + Random.Range(-2,0), 1, 10);
        int s3 = Mathf.Clamp(score + Random.Range(1,5), 1, 10);

        t1.text = s1.ToString();
        t2.text = s2.ToString();
        t3.text = s3.ToString();

        totalScore.text = (s1+s2+s3).ToString() + "/30";
    }
}
