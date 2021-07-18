using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//game manager to control basic game play functions
public class GameMaster : MonoBehaviour
{
    //variable shown in Inspector
    [SerializeField] public int m_Life = 3;

    //variables
    public static GameMaster gm;
    public static Text livesText;

    //initialize gamemaster object
    void Start()
    {

        if (gm == null)
        {
            gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        }
    }
    public Transform playerPrefab;
    public Transform spawnPoint;

    //spawnpoint of player
    public static void CheckPoint(Transform checkpoint)
    {
        gm.spawnPoint = checkpoint;
    }

    //respawn player at spawnpoint position
    public void RespawnPlayer()
    {
        Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
    }

    //destroys life points when called
    public static void KillPlayer(GameObject player)
    {
        Destroy(player.gameObject);
        gm.m_Life -= 1;
        livesText = GameObject.Find("LivesText").GetComponent<Text>();  //shows lives
        livesText.text = "Lives: " + gm.m_Life;                         //decrements lives

        if (gm.m_Life == 0)
        {
            Debug.Log("GameOver");                                      //restart game/game over when life points == 0
            SceneManager.LoadScene("GameOver");
        }
        gm.RespawnPlayer();

    }
    
    //gives additional life point
    public static void GiveLife()
    {
        gm.m_Life += 1;
        livesText = GameObject.Find("LivesText").GetComponent<Text>();  //show lives
        livesText.text = "Lives: " + gm.m_Life;
    }

}

