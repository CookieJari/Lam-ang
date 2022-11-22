using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public float damage;

    protected void OnTriggerEnter2D(Collider2D enemy)
    {
        if (enemy.tag == "Player")
        {
            //get the HitScript of the enemy that was hit
            Health hs = enemy.GetComponent("Health") as Health;
            //call the damage function
            hs.TakeDamage(damage, transform.position.x);

        }
              
    }

}