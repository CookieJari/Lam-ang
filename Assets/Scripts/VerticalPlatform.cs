using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalPlatform : MonoBehaviour
{

    private PlatformEffector2D effector;
    public float waitTime;
    // Start is called before the first frame update
    void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKey(KeyCode.Space)){
            effector.rotationalOffset = 0;
        }

        if(Input.GetKeyUp(KeyCode.DownArrow)|| Input.GetKeyUp("s"))
        {
            waitTime = 0.1f;
        }

        if(Input.GetKey(KeyCode.DownArrow) || Input.GetKey("s"))
        {
            if(waitTime <= 0){
                effector.rotationalOffset = 180f;
                waitTime = 0.1f;
            } else {
                waitTime -= Time.deltaTime;
            }
        }

    }
}
