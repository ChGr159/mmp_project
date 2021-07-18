using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//main menu controller
public class MenuManager : MonoBehaviour
{
    public GameObject HowTo;
    
    //initialize game and increment level index
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    //open tutorial
    public void Instructions()
    {
        HowTo.gameObject.SetActive(true);
    }

    //close tutorial
    public void CloseInstructions()
    {
        HowTo.gameObject.SetActive(false);
    }

    //exit game
    public void QuitGame()
    {
        Debug.Log("Spiel beendet");
        Application.Quit();
    }
}
