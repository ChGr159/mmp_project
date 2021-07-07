using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    [SerializeField] public int m_Life = 3;
    


    public static GameMaster gm;
    
    void Start()
    {
        if (gm == null)
        {
            gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        }
    }
    public Transform playerPrefab;
    public Transform spawnPoint;

    public static void CheckPoint(Transform checkpoint)
    {
        gm.spawnPoint = checkpoint;
    }

    public void RespawnPlayer ()
    {
        Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
    }
    public static void KillPlayer (GameObject player)
    {
        Destroy(player.gameObject);
        gm.m_Life -= 1;
        Debug.Log("Er hat " + gm.m_Life);                       // Ein Leben weg;
        
        if (gm.m_Life == 0)
        {
            Debug.Log("GameOver");                // Fangen wir das Spiel von vorne;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        gm.RespawnPlayer();
        
    }
    void OnGUI()                                    //Anzeige die Anzahl der Leben;
    {
        GUI.Box(new Rect(Screen.width - 100, 30, 90, 30), "Lives:" + m_Life);
    }
}

