using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class level1after : MonoBehaviour
{

public static bool isCutSceneOn;
public Animator camAnim;

// public Animator Scene4Anim;

void Start() {
    StartCoroutine(cutscene1());
}

IEnumerator cutscene1()
    {
        Debug.Log("B4 Level 2: Scene1 starts");
        camAnim.SetBool("cutscene1", true);
        yield return new WaitForSeconds(6.0f);
        StartCoroutine(cutscene2());
    }

IEnumerator cutscene2()
    {
        Debug.Log("B4 Level 2: Scene2 starts");
        camAnim.SetBool("cutscene2", true);
        yield return new WaitForSeconds(6.0f);
        StartCoroutine(cutscene3());
    }
IEnumerator cutscene3()
    {
        Debug.Log("B4 Level 2: Scene3 starts");
        camAnim.SetBool("cutscene3", true);
        yield return new WaitForSeconds(6.0f);
        StartCoroutine(cutscene4());
    }
IEnumerator cutscene4()
    {
        Debug.Log("B4 Level 2: Scene4 starts");
        // Scene4Anim.SetTrigger("start");
        camAnim.SetBool("cutscene4", true);
        yield return new WaitForSeconds(6.0f);
        StartCoroutine(cutscene5());
        
    }

IEnumerator cutscene5()
    {
        Debug.Log("B4 Level 2: Scene5 starts");
        // Scene4Anim.SetTrigger("start");
        camAnim.SetBool("cutscene5", true);
        yield return new WaitForSeconds(6.0f);
        StartCoroutine(cutscene6());
        
    }

IEnumerator cutscene6()
    {
        Debug.Log("B4 Level 2: Scene6 starts");
        // Scene4Anim.SetTrigger("start");
        camAnim.SetBool("cutscene6", true);
        yield return new WaitForSeconds(6.0f);
        StartCoroutine(cutscene7());
        
    }

IEnumerator cutscene7()
    {

        Debug.Log("B4 Level 2: Scene7 starts");
        // Scene4Anim.SetTrigger("start");
        camAnim.SetBool("cutscene7", true);
        yield return new WaitForSeconds(6.0f);
        StartCoroutine(loadlevel());
        
    }


    
IEnumerator loadlevel()
    {
        
        yield return new WaitForSeconds(3.0f);
        // Load Next level Scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}
