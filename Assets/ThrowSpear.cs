using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowSpear : MonoBehaviour
{
    public GameObject spear;
    public Transform shotPoint;

    // Trigger enabled is for enableing the checking of objects inside the trigger
    public bool triggerEnabled = false;
    // hasSpear to check if the player has the spear
    public bool hasSpear = true;
    public int launchForce;

    // countdown before the enabling the trigger again
    public float countdown;
    public float timer = 2f;

    public BoxCollider2D bc;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && hasSpear)
        {
            triggerEnabled = false;
            Shoot();
            
        }

        //start the trigger countdown
        enablePickup();
        // if countdown gets to 0 and player does not have the spear, enable the trigger
        if (countdown<=0 && !hasSpear)
        {
            triggerEnabled = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (triggerEnabled)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("Player Spear"))
            {
                Destroy(collision.gameObject);
                hasSpear = true;
                triggerEnabled = false;
            }
        }
    }

    void Shoot()
    {
        //create spear
        GameObject newSpear = Instantiate(spear, shotPoint.position, shotPoint.rotation);
        //give velocity
        newSpear.GetComponent<Rigidbody2D>().velocity = transform.right * launchForce;
        hasSpear = false;
        

    }

    void enablePickup()
    {
        if (hasSpear)
        {
            countdown = timer;
        }
        else
        {
           countdown -= Time.deltaTime;
        }
        
    }
}
