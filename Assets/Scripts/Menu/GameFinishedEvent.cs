using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class GameFinishedEvent : MonoBehaviour
{


     private void Start()
     {
        Time.timeScale = 1;
        
     }
     
    // Home Screen
    public void GoToMenu(){
       SceneManager.LoadScene(0);
    }


    // Quit Scene
    public void QuitScene() {
          Application.Quit();
    }

}
