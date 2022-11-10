using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BoulderTrap : MonoBehaviour
{
    [SerializeField] private float boulderTimer;
    public Transform spawnPoint;
    public Transform despawnPoint;

    private void Spawn()
    {
        GameObject boulder = ObjectPool.instance.GetPooledObject();
            if (boulder != null)
            {
                boulder.transform.position = spawnPoint.position;
                boulder.SetActive(true);
                
            }   
    }
   
    private void Update()
    {
        boulderTimer -= Time.deltaTime;
        if (boulderTimer <= 0)
        {
            Spawn();
            boulderTimer = 2f;
        }
    }
            
}
