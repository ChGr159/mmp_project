using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//switches level
public class LevelChanger : MonoBehaviour
{
    //variables
    public Animator animator;
    private int levelToLoad;

    // Update is called once per frame
    //if button pressed => level fade method called
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            LevelFade(1);
        }

    }

    //level fade out
    public void LevelFade(int levelIndex)
    {

        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");

    }

    //load next level
    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
