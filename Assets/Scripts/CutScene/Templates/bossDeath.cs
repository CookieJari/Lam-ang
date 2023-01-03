using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bossDeath : MonoBehaviour
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
        // Play first frame dialogue
        // b4_one.Play();
        Time.timeScale = 1f;
        Debug.Log("B4 Prologue: Scene1 starts");
        camAnim.SetBool("cutscene1", true);
        yield return new WaitForSeconds(6.0f);
        StartCoroutine(cutscene2());
    }

IEnumerator cutscene2()
    {
        
        // b4_two.Play();
        Debug.Log("B4 Prologue: Scene2 starts");
        camAnim.SetBool("cutscene2", true);
        yield return new WaitForSeconds(6.0f);
        StartCoroutine(cutscene3());
    }
IEnumerator cutscene3()
    {
        
        Debug.Log("B4 Prologue: Scene3 starts");
        camAnim.SetBool("cutscene3", true);
        yield return new WaitForSeconds(6.0f);
        StartCoroutine(cutscene4());
    }
IEnumerator cutscene4()
    {
        Debug.Log("B4 Prologue: Scene4 starts");
        Debug.Log("Scene4 starts");

        camAnim.SetBool("cutscene4", true);
        yield return new WaitForSeconds(6.0f);
        StartCoroutine(cutscene5());
        
    }

IEnumerator cutscene5()
    {
        Debug.Log("B4 Prologue: Scene5 starts");
        Debug.Log("Scene5 starts");

        camAnim.SetBool("cutscene5", true);
        yield return new WaitForSeconds(6.0f);
        StartCoroutine(cutscene6());
        
    }

IEnumerator cutscene6()
    {
        Debug.Log("B4 Prologue: Scene6 starts");
        
        camAnim.SetBool("cutscene6", true);
        yield return new WaitForSeconds(6.0f);
        StartCoroutine(cutscene7());
        
    }

IEnumerator cutscene7()
    {
        Debug.Log("B4 Prologue: Scene6 starts");
        
        camAnim.SetBool("cutscene7", true);
        yield return new WaitForSeconds(10.0f);
        StartCoroutine(loadlevel());
        
    }

    
IEnumerator loadlevel()
    {
        
        Debug.Log("Load Prologue Scene");
        yield return new WaitForSeconds(3.0f);
        // Load Prologue Scene
        main_theme.Stop();
        SceneManager.LoadScene(100);
        
    }


}
