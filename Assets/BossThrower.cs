using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossThrower : MonoBehaviour
{
    public GameObject projectile;
    public Transform tf;
    public float launchForce;

    // Start is called before the first frame update
    void Start()
    {
        // call function, delay 1s, repeat every 3s
        InvokeRepeating("Volley", 1f, 3f);
    }


    void Volley()
    {
        ThrowProjectile();
        Debug.Log("Throwing one volley");
    }

    void ThrowProjectile()
    {
        GameObject newProjectile =  Instantiate(projectile,tf);

        newProjectile.GetComponent<Rigidbody2D>().velocity = -transform.right * launchForce;
    }
}
