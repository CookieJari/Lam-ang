using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitScript : MonoBehaviour
{
    public int HP;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AtkHit(int dmg, float x)
    {
        float dist;
        //get the difference in distance to find out if attack is coming from left or right
        dist = transform.position.x - x;
        anim.SetFloat("HitLoc", dist);

        anim.SetTrigger("Hit");
        //animation

        //knockback

        //paralyze

        //damage
        HP -= dmg;
        Debug.Log("HIT FOR: "+ dmg);
    }
}
