using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private float StartingHealth;
    public float CurrentHealth { get; private set; }
    private Animator anime;
    private bool dead;

    private void Awake()
    {
        CurrentHealth = StartingHealth;
        anime = GetComponent<Animator>();
    }

    public void TakeDamage(float _damage)
    {
        CurrentHealth = Mathf.Clamp(CurrentHealth - _damage, 0, StartingHealth);

        if (CurrentHealth > 0)
        {
            anime.SetTrigger("Hurt");
        }
        else
        {
            if (!dead)
            {
                anime.SetTrigger("Die");
                if (GetComponent<Attack>() != null)
                    GetComponent<Attack>().enabled = false;

                if (GetComponent<PlayerMovement>() != null)
                    GetComponent<PlayerMovement>().enabled = false;

                if (GetComponentInParent<EnemyPatrol>() != null)
                    GetComponentInParent<EnemyPatrol>().enabled = false;

                if (GetComponent<Attacken1>() != null)
                    GetComponent<Attacken1>().enabled = false;

                dead = true;
            }
        }
    }

    public void HealthInc(float _inc)
    {
        CurrentHealth = Mathf.Clamp(CurrentHealth + _inc, 0, StartingHealth);
    }
    public void IncreaseMaxHealth(float amount)
    {
        StartingHealth += amount;
        CurrentHealth = Mathf.Clamp(CurrentHealth + amount, 0, StartingHealth);
    }
}


