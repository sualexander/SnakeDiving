using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuScript : MonoBehaviour
{
    public Animator jump;
    public Animator moveText;
    public Animator divingBoard;

    public float waitDuration;
    public float waitDuration2;
    public float waitDiving;
    public void onPlayButton()
    {
        StartCoroutine(StartGame());
    }

    public TMP_Text startButton;

    public Color defaultColor;
    public Color hoverColor;

    public AudioSource woosh;

    public void onHover()
    {
        startButton.color = hoverColor;
    }

    public void onUnHover()
    {
        startButton.color = defaultColor;
    }

    private IEnumerator StartGame()
    {
        

        moveText.enabled = true;
        moveText.Play("MoveText");



        yield return new WaitForSeconds(waitDuration);

        jump.enabled = true;
        jump.speed = 0.5f;
        jump.Play("SnakeJump");

        woosh.Play();

        yield return new WaitForSeconds(waitDiving);

        divingBoard.enabled = true;
        divingBoard.Play("DivingGone");

        yield return new WaitForSeconds(waitDuration2);
        SceneManager.LoadScene("Main");
    }

}
