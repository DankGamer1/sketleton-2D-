using UnityEngine;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health Playerhealth;
    [SerializeField] private Image CurrentHealthBar;
    public Image TotalHealthBar;
    private void Start()
    {
        CurrentHealthBar.fillAmount = Playerhealth.CurrentHealth / 10f;
    }

    private void Update()
    {
        CurrentHealthBar.fillAmount = Playerhealth.CurrentHealth / 10f;

    }
}
