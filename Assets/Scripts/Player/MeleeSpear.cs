using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeSpear : MonoBehaviour
{
    public Animator anim;
    public int damage;
    public string AttackBind;
    public LayerMask enemyLayer;
    public Transform attackPoint;
    public Vector2 attackSize;

    public bool validAtk;
    public float setTime;
    float timer;
    // Update is called once per frame
    void Update()
    {
        //Debug.Log(canAttack +"\t" + setInterval);
        if (Input.GetKey(AttackBind) && validAtk)
        {
            anim.SetTrigger("Stab");
            Attack();
            validAtk = false;
        }
        Timer();
    }

    void Attack()
    {
        //animation

        //detect enemy
        Collider2D[] hitEnemies = Physics2D.OverlapBoxAll(attackPoint.position,attackSize,0f,enemyLayer);
        //Damage enemy
        foreach (Collider2D enemy in hitEnemies)
        {
            //get the HitScript of the enemy that was hit
            Health hs = enemy.GetComponent("Health") as Health;
            //call the damage function
            hs.TakeDamage(damage, transform.parent.position.x);


        }
    }

    void Timer()
    {
        if (!validAtk)
        {
            if (timer>0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                timer = setTime;
                validAtk = true;
            }
        }
    }


    private void OnDrawGizmos()
    {
        if (attackPoint.position == null)
        {
            return;
        }
        Gizmos.DrawWireCube(attackPoint.position, attackSize);
    }

}
