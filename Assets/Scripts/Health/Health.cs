using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{
    public bool shieldUp;
    [Header("Health")]
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;

    [Header("iFrames")]
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteRend;

    [Header("Components")]
    [SerializeField] private Behaviour[] components;
    private bool invulnerable;

    [Header("Health Bar")]
    public HealthBarScript hbs;

    private void Awake()
    {
        currentHealth = startingHealth;
        hbs.SetMaxHealth(startingHealth);
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    //Player takes damage code
    public void TakeDamage(float dmg, float x)
    {
        if (shieldUp)
        {
            dmg /= 2;
        }

        if (invulnerable) return;
        currentHealth = Mathf.Clamp(currentHealth - dmg, 0, startingHealth);

        if (currentHealth > 0)
        {
            float dist;
            //get the difference in distance to find out if attack is coming from left or right
            dist = transform.position.x - x;
            anim.SetFloat("HitLoc", dist);

            anim.SetTrigger("Hit");
            StartCoroutine(Invunerability());
            //animation

            //knockback

            //paralyze

            //damage
            currentHealth -= dmg;
            Debug.Log("HIT FOR: " + dmg);
            hbs.SetHealth(currentHealth);
        }
        else
        {
            if (!dead)
            {
                anim.SetTrigger("die");

                //Deactivate all attached components (movement ba ito keneth?)
                foreach (Behaviour component in components)
                {
                    component.enabled = false;
                }

                dead = true;
                Destroy(gameObject);
            }
        }
    }
    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
        hbs.SetHealth(currentHealth);
    }
    //Invincibility Frames
    private IEnumerator Invunerability()
    {
        invulnerable = true;
        Physics2D.IgnoreLayerCollision(8, 10, true);
        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriteRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
        }
        Physics2D.IgnoreLayerCollision(8, 10, false);
        invulnerable = false;
    }
    
    //Removes Player When Dead
    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}