using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    [Header("Attack Parameters")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private float meleeRange;

    [SerializeField] private float damage;


    [Header("Spear Throwing")]
    [SerializeField] private float range;
    [SerializeField] private bool hasSpear = true;
    [SerializeField] private bool spearAnim = true;
    [SerializeField] private float launchForce;
    [SerializeField] private GameObject spear;
    [SerializeField] private Transform shotPoint;

    [Header("Collider Parameters")]
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;

    [Header("Player Layer")]
    [SerializeField] private LayerMask playerLayer;
    private float cooldownTimer = Mathf.Infinity;

    //References from other codes
    private Animator anim;
    private Health playerHealth;
    private EnemyPatrol enemyPatrol;

    private void Awake()
    {
        enemyPatrol = GetComponentInParent<EnemyPatrol>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        cooldownTimer += Time.deltaTime;

        //Attack only when player in sight
        if (PlayerInSight())
        {
            if (cooldownTimer >= attackCooldown)
            {
                cooldownTimer = 0;
                anim.SetTrigger("melee attack");

            }
        }

        if (PlayerInSightRange() && hasSpear)
        {
            anim.SetTrigger("Throw");
            hasSpear = false;
        }

        if (enemyPatrol != null)

            if (PlayerInSight() || (PlayerInSightRange() && spearAnim))
            {
                enemyPatrol.enabled = false;
            }
            else
            {
                enemyPatrol.enabled = true;
            }
        //enemyPatrol.enabled = !PlayerInSight() && !PlayerInSightRange() && (PlayerInSightRange() && !hasSpear);

    }

    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * meleeRange * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * meleeRange, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0, Vector2.left, 0, playerLayer);

        if (hit.collider != null)
            playerHealth = hit.transform.GetComponent<Health>();

        return hit.collider != null;
    }

    private bool PlayerInSightRange()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0, Vector2.left, 0, playerLayer);

        return hit.collider != null;
    }
    void Shoot()
    {

        //create spear
        GameObject newSpear = Instantiate(spear, shotPoint.position, shotPoint.rotation);
        //give velocity
        newSpear.GetComponent<Rigidbody2D>().velocity = transform.right * launchForce;
        EnemyDamage ed = newSpear.gameObject.GetComponent("EnemyDamage") as EnemyDamage;
        ed.damage = damage;
        hasSpear = false;

        //stop the trigger
        anim.ResetTrigger("Throw");

    }
    void FinishSpearAnim()
    {
        spearAnim = false;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * meleeRange * transform.localScale.x * colliderDistance,
           new Vector3(boxCollider.bounds.size.x * meleeRange, boxCollider.bounds.size.y, boxCollider.bounds.size.z));

        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
           new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));

    }

    //Damages Player
    private void DamagePlayer()
    {
        if (PlayerInSight())
        {
            playerHealth.TakeDamage(damage, transform.position.x);
        }
    }
}