using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    void NextLevel()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
