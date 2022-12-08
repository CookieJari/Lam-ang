using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;


public class DisableCutSceneCamera : MonoBehaviour
{
    public GameObject PreviousCutSceneCamera;
    public GameObject CurrentCutSceneCamera;
    public GameObject CurrentCutSceneTrigger;


    private void OnTriggerEnter2D(Collider2D collision) {

            if(collision.tag == "Player"){
        StartCoroutine(EnableMainCamera());
            }


    }

    IEnumerator EnableMainCamera()
    {
            Debug.Log("Hello this is cam");

            PreviousCutSceneCamera.SetActive(false);
            yield return new WaitForSeconds(30.0f);
            
            PreviousCutSceneCamera.SetActive(true);
            CurrentCutSceneCamera.SetActive(false);
            CurrentCutSceneTrigger.SetActive(false);
            Debug.Log("Bye this is cam");
            yield break;

    }


}
