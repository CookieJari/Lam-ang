using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitScript : MonoBehaviour
{
    public int HP;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AtkHit(int dmg)
    {
        //animation

        //knockback

        //paralyze

        //damage
        HP -= dmg;
        Debug.Log("HIT FOR: "+ dmg);
    }
}
