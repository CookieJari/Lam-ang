using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Prologue : MonoBehaviour
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
        Debug.Log("Prologue: Scene1 starts");
        camAnim.SetBool("cutscene1", true);
        yield return new WaitForSeconds(6.0f);
        StartCoroutine(cutscene2());
    }

IEnumerator cutscene2()
    {
        
        // b4_two.Play();
        Debug.Log("Prologue: Scene2 starts");
        camAnim.SetBool("cutscene2", true);
        yield return new WaitForSeconds(6.0f);
        StartCoroutine(cutscene3());
    }
IEnumerator cutscene3()
    {
        
        Debug.Log("Prologue: Scene3 starts");
        camAnim.SetBool("cutscene3", true);
        yield return new WaitForSeconds(6.0f);
        StartCoroutine(cutscene4());
    }
IEnumerator cutscene4()
    {
        Debug.Log("Prologue: Scene4 starts");
        Debug.Log("Scene5 starts");
        // Scene4Anim.SetTrigger("start");
        camAnim.SetBool("cutscene4", true);
        yield return new WaitForSeconds(6.0f);
        StartCoroutine(cutscene5());
        
    }

IEnumerator cutscene5()
    {
        Debug.Log("Prologue: Scene5 starts");
        // Scene4Anim.SetTrigger("start");
        camAnim.SetBool("cutscene5", true);
        yield return new WaitForSeconds(6.0f);
        StartCoroutine(cutscene6());
        
    }

IEnumerator cutscene6()
    {
        Debug.Log("Prologue: Scene6 starts");
        // Scene4Anim.SetTrigger("start");
        camAnim.SetBool("cutscene6", true);
        yield return new WaitForSeconds(6.0f);
        StartCoroutine(cutscene7());
        
    }

IEnumerator cutscene7()
    {
        Debug.Log("Prologue: Scene7 starts");
        // Scene4Anim.SetTrigger("start");
        camAnim.SetBool("cutscene7", true);
        yield return new WaitForSeconds(6.0f);
        StartCoroutine(cutscene8());
        
    }

IEnumerator cutscene8()
    {
        Debug.Log("Prologue: Scene8 starts");
        // Scene4Anim.SetTrigger("start");
        camAnim.SetBool("cutscene8", true);
        yield return new WaitForSeconds(6.0f);
        StartCoroutine(cutscene9());
        
    }
IEnumerator cutscene9()
    {
        Debug.Log("Prologue: Scene9 starts");
        // Scene4Anim.SetTrigger("start");
        camAnim.SetBool("cutscene9", true);
        yield return new WaitForSeconds(6.0f);
        StartCoroutine(cutscene10());
        
    }
IEnumerator cutscene10()
    {
        Debug.Log("Prologue: Scene10 starts");
        // Scene4Anim.SetTrigger("start");
        camAnim.SetBool("cutscene10", true);
        yield return new WaitForSeconds(6.0f);
        StartCoroutine(cutscene11());
        
    }
IEnumerator cutscene11()
    {
        Debug.Log("Prologue: Scene11 starts");
        // Scene4Anim.SetTrigger("start");
        camAnim.SetBool("cutscene11", true);
        yield return new WaitForSeconds(6.0f);
        StartCoroutine(cutscene12());
        
    }
IEnumerator cutscene12()
    {
        Debug.Log("Prologue: Scene12 starts");
        // Scene4Anim.SetTrigger("start");
        camAnim.SetBool("cutscene12", true);
        yield return new WaitForSeconds(6.0f);
        StartCoroutine(cutscene13());
        
    }
IEnumerator cutscene13()
    {
        Debug.Log("Prologue: Scene13 starts");
        // Scene4Anim.SetTrigger("start");
        camAnim.SetBool("cutscene13", true);
        yield return new WaitForSeconds(6.0f);
        StartCoroutine(cutscene14());
        
    }
IEnumerator cutscene14()
    {
        Debug.Log("Prologue: Scene14 starts");
        // Scene4Anim.SetTrigger("start");
        camAnim.SetBool("cutscene14", true);
        yield return new WaitForSeconds(6.0f);
        StartCoroutine(cutscene15());
        
    }
IEnumerator cutscene15()
    {
        Debug.Log("Prologue: Scene15 starts");
        // Scene4Anim.SetTrigger("start");
        camAnim.SetBool("cutscene15", true);
        yield return new WaitForSeconds(6.0f);
        StartCoroutine(cutscene16());
        
    }
IEnumerator cutscene16()
    {
        Debug.Log("Prologue: Scene16 starts");
        // Scene4Anim.SetTrigger("start");
        camAnim.SetBool("cutscene16", true);
        yield return new WaitForSeconds(6.0f);
        StartCoroutine(cutscene17());
        
    }
IEnumerator cutscene17()
    {
        Debug.Log("Prologue: Scene17 starts");
        // Scene4Anim.SetTrigger("start");
        camAnim.SetBool("cutscene17", true);
        yield return new WaitForSeconds(6.0f);
        StartCoroutine(cutscene18());
        
    }
IEnumerator cutscene18()
    {
        Debug.Log("Prologue: Scene18 starts");
        // Scene4Anim.SetTrigger("start");
        camAnim.SetBool("cutscene18", true);
        yield return new WaitForSeconds(6.0f);
        StartCoroutine(cutscene19());
        
    }
IEnumerator cutscene19()
    {
        Debug.Log("Prologue: Scene19 starts");
        // Scene4Anim.SetTrigger("start");
        camAnim.SetBool("cutscene19", true);
        yield return new WaitForSeconds(6.0f);
        StartCoroutine(cutscene20());
        
    }
IEnumerator cutscene20()
    {
        Debug.Log("Prologue: Scene20 starts");
        // Scene4Anim.SetTrigger("start");
        camAnim.SetBool("cutscene20", true);
        yield return new WaitForSeconds(6.0f);
        StartCoroutine(loadlevel());
        
    }
    

IEnumerator loadlevel()
    {
        
        Debug.Log("Load Prologue Scene");
        yield return new WaitForSeconds(3.0f);
        // Load Prologue Scene
        main_theme.Stop();
        SceneManager.LoadScene(2);
        
    }


}
