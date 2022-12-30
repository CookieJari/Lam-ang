using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowSpear : MonoBehaviour
{
    [SerializeField]
    AudioSource range_attack;

    [SerializeField]
    AudioSource spear_pickup;

    public GameObject spear;
    public Transform shotPoint;
    public int damage;

    // Trigger enabled is for enableing the checking of objects inside the trigger
    public bool triggerEnabled = false;
    // hasSpear to check if the player has the spear
    public bool hasSpear = true;
    public int launchForce;

    // countdown before the enabling the trigger again
    public float countdown;
    public float timer = 2f;

    public bool shieldUp;

    public Animator anim;

    public BoxCollider2D bc;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && hasSpear && !shieldUp)
        {
            range_attack.Play();
            triggerEnabled = false;
            anim.SetTrigger("Throw");

        }

        //start the trigger countdown
        enablePickup();
        // if countdown gets to 0 and player does not have the spear, enable the trigger
        if (countdown<=0 && !hasSpear)
        {
            triggerEnabled = true;
        }
    }

    // this is to grab the spear
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (triggerEnabled)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("Player Spear"))
            {
                spear_pickup.Play();
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
        Spear sp = newSpear.gameObject.GetComponent ("Spear") as Spear;
        sp.damage = damage;
        hasSpear = false;

        //stop the trigger
        anim.ResetTrigger("Throw");

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

    // This script calls the melee script from "AttackPoint" gameObject so that this function can be used for the animation event
    public MeleeSpear melee;

    void Attack()
    {
        melee.Invoke("Attack",0f);
    }
}
