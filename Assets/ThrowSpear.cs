using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowSpear : MonoBehaviour
{
    public GameObject spear;
    public Transform shotPoint;
    public bool hasSpear;
    public int launchForce;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            //instantiate a spear
            Shoot();
        }
    }

    void Shoot()
    {
        //create spear
        GameObject newSpear = Instantiate(spear, shotPoint.position, shotPoint.rotation);
        //give velocity
        newSpear.GetComponent<Rigidbody2D>().velocity = transform.right * launchForce;
        hasSpear = false;
    }
}
