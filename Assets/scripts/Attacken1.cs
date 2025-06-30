using UnityEngine;

public class Attacken1 : MonoBehaviour
{
    [SerializeField] private float attackcooldown;
    [SerializeField] private float range;
    [SerializeField] private float colliderdistance;
    [SerializeField] private float damage;
    [SerializeField] private BoxCollider2D boxcollider;
    [SerializeField] private LayerMask playerlayer;

    private Animator anim;
    private Health PlayerHealth;
    private float cooldowntimer = Mathf.Infinity;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        cooldowntimer += Time.deltaTime;

        if (PlayerInSight())
        {
            if (cooldowntimer >= attackcooldown)
            {
                cooldowntimer = 0;
                anim.SetTrigger("AttackTrigger");
            }
        }
    }

    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(
            boxcollider.bounds.center + transform.right * range * transform.localScale.x * colliderdistance,
            new Vector3(boxcollider.bounds.size.x * range, boxcollider.bounds.size.y, boxcollider.bounds.size.z),
            0,
            Vector2.left,
            0,
            playerlayer
        );

        if (hit.collider != null)
            PlayerHealth = hit.transform.GetComponent<Health>();

        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(
            boxcollider.bounds.center + transform.right * range * transform.localScale.x * colliderdistance,
            new Vector3(boxcollider.bounds.size.x * range, boxcollider.bounds.size.y, boxcollider.bounds.size.z)
        );
    }

    private void DamagePlayer()
    {
        if (PlayerInSight())
            PlayerHealth.TakeDamage(damage);
    }
}


