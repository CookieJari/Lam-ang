using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveOnDamage : MonoBehaviour
{
    public GameObject go;
    public float destroyDelay;
    public LayerMask lm;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("col all: \t" + collision.gameObject.layer);
        Debug.Log(lm.value);
        if ((lm.value & (1 << collision.transform.gameObject.layer)) > 0)
        {
            Debug.Log("col");
            StartCoroutine(Destroy());
        }
        
    }
    IEnumerator Destroy()
    {
        Debug.Log("Destorying in few:");
        yield return new WaitForSeconds(destroyDelay);
        Debug.Log("Destroyed");
        Destroy(go);
    }
}
