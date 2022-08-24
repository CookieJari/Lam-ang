using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearCheck : MonoBehaviour
{
    // Start is called before the first frame update

    public bool triggerEnabled = true;
    // Update is called once per frame
 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (triggerEnabled)
        {
            Debug.Log(collision.gameObject.name);
            if (collision.gameObject.layer == LayerMask.NameToLayer("Player Spear"))
            {
                Debug.Log("OMG MY SPEAR");
                triggerEnabled = false;
            }
        }
    }
        
}
