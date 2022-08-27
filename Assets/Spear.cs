using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : MonoBehaviour
{
    public float rotation;
    public Rigidbody2D rb;
    public bool hit = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        hit = true;
        rb.velocity = Vector2.zero;
        rb.isKinematic = true;
        Debug.Log("stop");
    }
    // Update is called once per frame
    void Update()
    {
        if (!hit)
        {
            rotation = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(rotation, Vector3.forward);
            Debug.Log("shooting");
        }
        
    }
}
