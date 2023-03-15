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
    audioSource.PlayOneShot(butterflySound, 1.5f);
}

public void hitWater()
{
    audioSource.PlayOneShot(splashSound, 2f);
    audioSource.PlayOneShot(cheerSound, 2f);
}

public void receiveScore()
{
    audioSource.PlayOneShot(judgeSound, 2.5f);
}

public void touchWeb()
{
    audioSource.PlayOneShot(cobwebSound, 2);
}

public void cheer()
{
    audioSource.PlayOneShot(cheerSound, 1.5f);
}

}
