using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerManager : MonoBehaviour
{

    public GameObject pauseMenuScreen;

     private void Start()
     {
        Time.timeScale = 1;
        
     }
     
    // Start is called before the first frame update
    public void PauseGame() {
        Time.timeScale = 0;
        pauseMenuScreen.SetActive(true);
    }

    public void ResumeGame() {
        Time.timeScale = 1;
        pauseMenuScreen.SetActive(false);
    }

    public void GoToMenu(){
        SceneManager.LoadScene("Menu");
    }
}
