using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitScript : MonoBehaviour
{
    public int HP;
    public bool dead;
    public Animator anim;

    [Header("Components")]
    [SerializeField] private Behaviour[] components;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int dmg, float x)
    {
        if (HP > 0)
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
            Debug.Log("HIT FOR: " + dmg);
        }
        else
        {
            if (!dead)
            {
                anim.SetTrigger("die");

                //Deactivate all attached components
                foreach (Behaviour component in components)
                {
                    component.enabled = false;
                }
                dead = true;
            }
        }
    }
}
