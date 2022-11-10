
using UnityEngine;

public class BoulderDespawn : MonoBehaviour
{
    private float lifetime;
    // Update is called once per frame
 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            gameObject.SetActive(false);
        }
            
        if (collision.gameObject.CompareTag("Despawn"))
        {
            gameObject.SetActive(false);
        }
        
    }
}
