using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuEvents : MonoBehaviour
{

     
     public void LoadLevel(int index) {
        // 
        SceneManager.LoadScene(index);
        // get the index via file and build setttings
     }
}
