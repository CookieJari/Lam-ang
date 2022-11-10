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
        if ((lm.value & (1 << collision.transform.gameObject.layer)) > 0)
        {
            StartCoroutine(Destroy());
        }
        
    }
    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(destroyDelay);
        Destroy(go);
    }
}
