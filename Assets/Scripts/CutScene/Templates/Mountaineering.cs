using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mountaineering : MonoBehaviour
{

public static bool isCutSceneOn;
public Animator camAnim;
// public Animator Scene4Anim;

[SerializeField]
AudioSource main_theme;
// [SerializeField]
// AudioSource b4_one;
// [SerializeField]
// AudioSource b4_two;


void Start() {
    // Play bg music
    main_theme.Play();

    StartCoroutine(cutscene1());
}

IEnumerator cutscene1()
    {
        Time.timeScale = 1f;
        Debug.Log("Mountaineering: Scene1 starts");
        camAnim.SetBool("cutscene1", true);
        yield return new WaitForSeconds(6.0f);
        StartCoroutine(cutscene2());
    }

IEnumerator cutscene2()
    {
        
        Debug.Log("Mountaineering: Scene2 starts");
        camAnim.SetBool("cutscene2", true);
        yield return new WaitForSeconds(6.0f);
        StartCoroutine(loadlevel());
    }

    
IEnumerator loadlevel()
    {
        
        Debug.Log("Load Level 1 Scene");
        yield return new WaitForSeconds(3.0f);
        // Load Level 1 Scene
        main_theme.Stop();
        SceneManager.LoadScene(4);
        
    }


}
