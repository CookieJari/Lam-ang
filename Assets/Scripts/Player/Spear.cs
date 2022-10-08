using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : MonoBehaviour
{
    public int damage;
    public float rotation;
    public Rigidbody2D rb;
    public bool hit = false;
    public LayerMask enemyLayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        hit = true;
        // ---------------- WARNING !!! DO NOT RE ARRANGE THE LAYERS ----------------- (if you do hits will not work)
        if (collision.gameObject.layer ==10)
        {
            //get the HitScript of the enemy that was hit
            HitScript hs = collision.gameObject.GetComponent("HitScript") as HitScript;
            //call the damage function
            hs.TakeDamage(damage, transform.position.x);
        }
        
        rb.velocity = Vector2.zero;
        rb.isKinematic = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (!hit)
        {
            rotation = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(rotation, Vector3.forward);
        }
        
    }
}
