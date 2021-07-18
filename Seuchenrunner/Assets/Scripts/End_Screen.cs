using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//screen appears at end of every level
public class End_Screen : MonoBehaviour
{
    public GameObject Endscrn;

    //end screen appears when triggered by player
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            SoundManager.PlaySound("finish");  //applause at the end of the level
            Endscrn.gameObject.SetActive(true);
        }
    }

    //Buttons for 2nd level, restart, main menu
    public void NextLevel()
    {
        SceneManager.LoadScene("Level2");
    }
    public void RestartButton()
    {
        SceneManager.LoadScene("BaseCityGame");

    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
