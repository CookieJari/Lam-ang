using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : MonoBehaviour
{
    public int damage;
    public float rotation;
    public Rigidbody2D rb;
    public bool hit = false;
    public LayerMask lm;

    private GameObject go;
    private GameObject player;

    private void OnDisable()
    {
        player = GameObject.Find("Player");
        ThrowSpear ts = player.gameObject.GetComponent("ThrowSpear") as ThrowSpear;
        ts.hasSpear = true;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        hit = true;
        // ---------------- WARNING !!! DO NOT RE ARRANGE THE LAYERS ----------------- (if you do hits will not work)
        if ((lm.value & (1 << collision.transform.gameObject.layer)) > 0)
        {
            //get the HitScript of the enemy that was hit
            HitScript hs = collision.gameObject.GetComponent("HitScript") as HitScript;
            //call the damage function
            hs.TakeDamage(damage, transform.position.x);
            //parent spear to hit object so it will stick to the thing
            go = collision.gameObject;
            gameObject.transform.parent = go.transform;
        }
        
        rb.velocity = Vector2.zero;
        rb.isKinematic = true;
    }
    // Update is called once per frame
    void Update()
    {

        // This is to give the spear rotation while it moves about
        if (!hit)
        {
            rotation = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(rotation, Vector3.forward);
        }

        
    }
}
