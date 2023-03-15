using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public Animator jump;
    public Animator moveText;
    public void onPlayButton()
    {
        StartCoroutine(StartGame());
    }

    private IEnumerator StartGame()
    {
        jump.enabled = true;
        jump.speed = 0.5f;
        jump.Play("SnakeJump");

        moveText.enabled = true;
        moveText.Play("MoveText");

        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Main");
    }

}
