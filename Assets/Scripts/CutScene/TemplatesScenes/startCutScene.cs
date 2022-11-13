using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startCutScene : MonoBehaviour
{

    public static bool isCutSceneOn;
    public Animator camAnim;
    public GameObject textHolderCutScene;

   private void OnTriggerEnter2D(Collider2D collision)
   {

    if(collision.tag == "Player")
        {

        StartCoroutine(StartCutSceneDisplay1());

        }

    }
   
 IEnumerator StartCutSceneDisplay1()
    {
        camAnim.SetBool("cutScene1", true);
        yield return new WaitForSeconds(6.0f);
        StartCoroutine(StartCutSceneDisplay2());
        Invoke(nameof(StopCutScene1), 15.0f);
    }
 IEnumerator StartCutSceneDisplay2()
    {
        camAnim.SetBool("cutScene2", true);
        yield return new WaitForSeconds(5.0f);
        StartCoroutine(StartCutSceneDisplay3());
        Invoke(nameof(StopCutScene2), 8.0f);
    }
 IEnumerator StartCutSceneDisplay3()
    {
        camAnim.SetBool("cutScene3", true);
        yield return new WaitForSeconds(6.0f);
        Invoke(nameof(StopCutScene3), 6.0f);


    }




// Methods for Disabling CutScenes

    void StopCutScene1() {
        camAnim.SetBool("cutScene1", false);
                camAnim.SetBool("cutScene2", false);
                       camAnim.SetBool("cutScene3", false);
        Destroy(gameObject);
        textHolderCutScene.SetActive(false);
    }

    void StopCutScene2() {
        camAnim.SetBool("cutScene2", false);
        //Destroy(gameObject);
    }
    
    void StopCutScene3() {
        camAnim.SetBool("cutScene3", false);
        //Destroy(gameObject);
    }



}
