using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public string switchKey = "E";
    bool playerInsidePortal;

    public Vector2 NextLevelPos;
    public GameObject go;
    public GameMaster gm;

    private void Update()
    {
        if (playerInsidePortal && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("changing levels");
            NextLevel();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            playerInsidePortal = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerInsidePortal = false;

        }
    }

    public void AdjustGameMaster(Vector2 nextPos)
    {
        go = GameObject.Find("Game Master");
        gm = go.GetComponent("GameMaster") as GameMaster;
        gm.lastCheckPointPos = nextPos;
    }

    public void NextLevel()
    {
        AdjustGameMaster(NextLevelPos);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        
    }
}
