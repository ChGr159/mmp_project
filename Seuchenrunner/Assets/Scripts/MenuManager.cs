using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject HowTo;
    
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void Instructions()
    {
        HowTo.gameObject.SetActive(true);
    }
    public void CloseInstructions()
    {
        HowTo.gameObject.SetActive(false);
    }

    public void QuitGame()
    {
        Debug.Log("Spiel beendet");
        Application.Quit();
    }
}
