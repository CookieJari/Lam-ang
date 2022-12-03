using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossThrower : MonoBehaviour
{
    public GameObject projectile;
    public GameObject volley1;
    public GameObject volley2;
    public Transform tf;
    public float betweenVolleys;
    public float launchForce;

    // Start is called before the first frame updatez
    void Start()
    {
        // call function, delay 1s, repeat every 3s
        //InvokeRepeating("StartVolley", 1f, 3f);
    }

    //I enumerator because we want to wait between volleys
    IEnumerator Volleys()
    {
        // does a volley for the first volley child
        for (int i = 0; i < volley1.transform.childCount; i++)
        {
            Transform tform = volley1.transform.GetChild(i);

            ThrowProjectile(tform);
        }

        yield return new WaitForSeconds(betweenVolleys);

        for (int i = 0; i < volley2.transform.childCount; i++)
        {
            Transform tform = volley2.transform.GetChild(i);

            ThrowProjectile(tform);
        }

    }
    //calls the co routine
    void StartVolley()
    {
        StartCoroutine(Volleys());
    }

    void ThrowProjectile(Transform trans)
    {
        GameObject newProjectile =  Instantiate(projectile,trans);

        newProjectile.GetComponent<Rigidbody2D>().velocity = -trans.right * launchForce;
    }
}
