using UnityEngine;

public class Boss_Run : MonoBehaviour
{
    [Header("Boss Settings")]
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float followRange = 10f;

    [Header("References")]
    [SerializeField] private Transform player; // Assign in Inspector

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.position);

        if (distance <= followRange)
        {
            float direction = player.position.x - transform.position.x;

            // Move only on X axis
            rb.linearVelocity = new Vector2(Mathf.Sign(direction) * moveSpeed, rb.linearVelocity.y);

            // Flip based on direction
            spriteRenderer.flipX = (direction < 0f); // True = face left, False = face right
        }
        else
        {
            // Stop moving if out of range
            rb.linearVelocity = new Vector2(0f, rb.linearVelocity.y);
        }
    }
}


