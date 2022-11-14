using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class PlayerManager : MonoBehaviour
{

    public GameObject pauseMenuScreen;
    public GameObject gameOverMenuScreen;

     private void Start()
     {
        Time.timeScale = 1;
        
     }
     
    // Home Screen
    public void GoToMenu(){
        SceneManager.LoadScene("Menu");
    }


    // Pause Button Screen
    public void PauseGame() {
        Time.timeScale = 0;
        pauseMenuScreen.SetActive(true);
    }



    public void ResumeGame() {
        Time.timeScale = 1;
        pauseMenuScreen.SetActive(false);
    }


    // Game Over Screen
    public void GameOver() {
        Time.timeScale = 0;
        gameOverMenuScreen.SetActive(true);

    }

    // Restart Scene
    public void RestartScene() {
          SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
