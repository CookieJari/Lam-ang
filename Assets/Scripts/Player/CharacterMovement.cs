using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D body;
    private NPC_Controller npc;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!inDialogue())
        {
            float verticalInput = Input.GetAxis("Vertical") * speed * Time.deltaTime;
            float horizontalInput = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
                body.velocity = new Vector2(0, verticalInput);
            else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
                body.velocity = new Vector2(horizontalInput, 0);
            else
                body.velocity = new Vector2(0, 0);
        }
    }

    private bool inDialogue()
    {
        if (npc != null)
            return npc.DialogueActive();
        else
            return false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "NPC")
        {
            npc = collision.gameObject.GetComponent<NPC_Controller>();

            if (Input.GetKey(KeyCode.E))
                npc.ActivateDialogue();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        npc = null;
    }
}