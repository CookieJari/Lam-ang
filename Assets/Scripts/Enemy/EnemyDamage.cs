using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] protected float damage;
    
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            collision.GetComponent<Health>().TakeDamage(damage, transform.position.x);
        Debug.Log("You took damage!");
    }
}