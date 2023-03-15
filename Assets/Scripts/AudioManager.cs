using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip BGM;
    public AudioClip splashSound;
    public AudioClip butterflySound;
    public AudioClip cheerSound;
    public AudioClip judgeSound;
    public AudioClip cobwebSound;

public void touchButterfly()
{
    audioSource.PlayOneShot(butterflySound, 1);
}

public void hitWater()
{
    audioSource.PlayOneShot(splashSound, 1);
    audioSource.PlayOneShot(cheerSound, 1);
}

public void receiveScore()
{
    audioSource.PlayOneShot(judgeSound, 1);
}

public void touchWeb()
{
    audioSource.PlayOneShot(cobwebSound, 1);
}
}
