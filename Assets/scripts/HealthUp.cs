 using UnityEngine;
using UnityEngine.UI;

public class HealthUp : MonoBehaviour
{
    [SerializeField] private float increaseAmount = 1f;
    [SerializeField] private HealthBar healthBarScript; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Health playerHealth = collision.GetComponent<Health>();

            if (playerHealth != null)
            {
                
                playerHealth.IncreaseMaxHealth(increaseAmount);

                
                if (healthBarScript != null)
                {
                    healthBarScript.TotalHealthBar.fillAmount += 0.1f;
                }
            }

            Destroy(gameObject); 
        }
    }
}


