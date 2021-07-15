using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    public static AudioClip soundCoins, soundEnemyHit, soundPlayerJump;
    static AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        soundPlayerJump = Resources.Load<AudioClip>("SoundPlayerJump");
        soundEnemyHit = Resources.Load<AudioClip>("SoundEnemyHit");
        soundCoins = Resources.Load<AudioClip>("SoundCoins");

        audioSource = GetComponent<AudioSource>();
    }

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
        }
    }
}
