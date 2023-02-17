using UnityEngine;

public class BoulderDespawn : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            gameObject.SetActive(false);
        }

        if (collision.tag == "Despawn")
        {
            gameObject.SetActive(false);
        }

    }
}
