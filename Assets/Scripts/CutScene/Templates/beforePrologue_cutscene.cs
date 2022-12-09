using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class beforePrologue_cutscene : MonoBehaviour
{

public static bool isCutSceneOn;
public Animator camAnim; 

void Start() {
    StartCoroutine(cutscene1());
}

IEnumerator cutscene1()
    {
        camAnim.SetBool("cutscene1", true);
        yield return new WaitForSeconds(6.0f);
        StartCoroutine(cutscene2());
    }

IEnumerator cutscene2()
    {
        camAnim.SetBool("cutscene2", true);
        yield return new WaitForSeconds(6.0f);
        StartCoroutine(cutscene3());
    }
IEnumerator cutscene3()
    {
        camAnim.SetBool("cutscene3", true);
        yield return new WaitForSeconds(6.0f);
        StartCoroutine(cutscene4());
    }
IEnumerator cutscene4()
    {
        camAnim.SetBool("cutscene4", true);
        yield return new WaitForSeconds(6.0f);
        StartCoroutine(cutscene5());
    }
IEnumerator cutscene5()
    {
        camAnim.SetBool("cutscene5", true);
        yield return new WaitForSeconds(6.0f);
        StartCoroutine(loadlevel());
    }
IEnumerator loadlevel()
    {
        
        yield return new WaitForSeconds(3.0f);
        // Load Prologue Scene
        SceneManager.LoadScene(0);
        
    }
}
