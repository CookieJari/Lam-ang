using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

     public float shootSpeed, shootTimer;
    private bool isShooting;
    public Transform shootPos;
    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        isShooting = false;
    }



        
   



    // Update is called once per frame
    void Update()
    {


        if(Input.GetButtonDown("Fire1") && !isShooting)
        {
            // Shoot Function
            StartCoroutine(Shoot());

        }


        // Make bullet change base on keys left or right arrow
        if (Input.GetKey("left") && (Input.GetButtonDown("Fire1")))
        {
            // Player turns left
           shootSpeed = shootSpeed * -1;

        }

        // Make bullet change base on keys left or right arrow
        if (Input.GetKey("right") && (Input.GetButtonDown("Fire1")))
        {
            // Player turns left
           shootSpeed = shootSpeed * 1;

        }


    }




    







    IEnumerator Shoot()
    {

        // int direction()
        // {

        //     //  if(transform.localScale.x < 0f)    
        //     if (Input.GetKey("left"))
        //     {
        //         shootSpeed = shootSpeed * 1;
        //         return -1;
                
        //     }
        //     else
        //     {
        //         shootSpeed = shootSpeed * -1;
        //         return -1;
        //     }
        // }



        isShooting = true;
        // Debug.Log("Shooting Bullet for Box");
        GameObject newBullet = Instantiate(bullet, shootPos.position, Quaternion.identity);
        newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(shootSpeed  * Time.fixedDeltaTime, 0f);
        
        newBullet.transform.localScale = new Vector2(newBullet.transform.localScale.x  , newBullet.transform.localScale.y);

        // Shoot Position Here

        yield return new WaitForSeconds(shootTimer);
        isShooting = false;

    }
}
