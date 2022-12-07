using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealthScript : MonoBehaviour
{
    public HitScript hs;
    public HealthBarScript hbs;
 
    // Start is called before the first frame update
    void Start()
    {
        hbs.SetMaxHealth(hs.startingHealth);

    }

    // Update is called once per frame
    void Update()
    {
        hbs.SetHealth(hs.HP);
    }
}
