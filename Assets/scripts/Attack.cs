using UnityEngine;

public class Attack : MonoBehaviour
{
    private Animator anime;

    [SerializeField] private float attackCooldown = 1f;
    [SerializeField] private float damage = 1f;
    [SerializeField] private Collider2D attackHitbox; // ← drag child collider here in Inspector

    private float lastAttackTime = -Mathf.Infinity;

    private void Awake()
    {
        anime = GetComponent<Animator>();
        attackHitbox.enabled = false; // disable hitbox by default
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time >= lastAttackTime + attackCooldown)
        {
            anime.SetTrigger("Attack");
            lastAttackTime = Time.time;

            // Activate the attack hitbox briefly
            attackHitbox.enabled = true;
            Invoke(nameof(DisableHitbox), 0.2f); // Show hitbox for 0.2 seconds
        }
    }

    private void DisableHitbox()
    {
        attackHitbox.enabled = false;
    }
}













