using UnityEngine;

public class AddHealth : MonoBehaviour
{
    [SerializeField] private float _AddHealth;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<Health>().HealthInc(_AddHealth);
            gameObject.SetActive(false);

        }
    }
}
