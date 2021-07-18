using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//controls sound effects and background music
public class SoundManager : MonoBehaviour
{
    //variables shown in Inspector
    [SerializeField]
    public static AudioClip soundCoins, soundEnemyHit, soundPlayerJump, soundWinner;
    static AudioSource audioSource;

    // Start is called before the first frame update
    //load sound clips for effects
    void Start()
    {
        soundPlayerJump = Resources.Load<AudioClip>("SoundPlayerJump");
        soundEnemyHit = Resources.Load<AudioClip>("SoundEnemyHit");
        soundCoins = Resources.Load<AudioClip>("SoundCoins");
        soundWinner = Resources.Load<AudioClip>("SoundApplause");

        audioSource = GetComponent<AudioSource>();
    }

    //play audio clips at triggered events
    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "jump":
                audioSource.PlayOneShot(soundPlayerJump);
                break;
            case "hit":
                audioSource.PlayOneShot(soundEnemyHit);
                break;
            case "coins":
                audioSource.PlayOneShot(soundCoins);
                break;
            case "finish":
                audioSource.PlayOneShot(soundWinner);
                break;
        }
    }
}
