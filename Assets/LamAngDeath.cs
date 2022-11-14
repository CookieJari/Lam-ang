using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LamAngDeath : MonoBehaviour
{
    // Create an object referencing the PlayerManager class
    public GameObject PlayerManagerScript;

    // This function will be called once lam-ang dies
    private void OnDestroy()
    {
        // Call GameOver Screen
        PlayerManagerScript.GetComponent<PlayerManager>().GameOver();
    }
}

