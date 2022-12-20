using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitScript : MonoBehaviour
{

    // [SerializeField]
    // AudioSource enemy_destroyed;

    public int HP;
    public bool dead;
    public Animator anim;
    private SpriteRenderer spriteRend;
    [SerializeField] private float numberOfFlashes;

    [Header("Components")]
    [SerializeField] private Behaviour[] components;

    [Header("Health Bar")]
    public int startingHealth;

    private void Awake()
    {
        startingHealth=HP;
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }
    public void TakeDamage(int dmg, float x)
    {
        if (HP > 0)
        {
            
            float dist;
            //get the difference in distance to find out if attack is coming from left or right
            dist = transform.position.x - x;
            anim.SetFloat("HitLoc", dist);


            //animation
            anim.SetTrigger("Hit");
            StartCoroutine(Flashing());
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
    private IEnumerator Flashing()
    {

        {
            spriteRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(numberOfFlashes);
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(numberOfFlashes);
        }

    }

    public void KillSelf()
    {
        Destroy(transform.parent.gameObject);
    }
}
