using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    [SerializeField] private float healthValue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("HEALTH PICKED");
            collision.GetComponent<Health>().AddHealth(healthValue);
            gameObject.SetActive(false);
        }
    }
}
