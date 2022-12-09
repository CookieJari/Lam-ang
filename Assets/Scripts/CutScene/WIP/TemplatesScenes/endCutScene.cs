using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endCutScene : MonoBehaviour
{

    public static bool isCutSceneOn;
    public Animator camAnim;

   private void OnTriggerEnter2D(Collider2D collision)
   {
    if(collision.tag == "Player")
        Debug.Log("Start");
        camAnim.SetBool("cutScene2", true);
        Invoke(nameof(StopCutScene), 10f);
        Debug.Log("End");
    }
   

    void StopCutScene() {
        camAnim.SetBool("cutScene2", false);
        Destroy(gameObject);
    }
}
