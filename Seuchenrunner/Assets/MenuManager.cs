using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{ 
    
    public void StartGame()
    {
        SceneManager.LoadScene("BaseCityGame 1");
    }

    public void QuitGame()
    {
        Debug.Log("Spiel beendet");
        Application.Quit();
    }
}
