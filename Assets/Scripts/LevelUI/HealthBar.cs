using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public static HealthBar Instance { get; private set; }

    [SerializeField]
    private Slider healthBarSlider;
    
    private int maxHealth;
    private int currentHealth;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        SetHealthBarValue();
    }

    private void SetHealthBarValue()
    {
        switch (PlayerPrefs.GetInt("PurchasedProtective"))
        {
            case 0:
                maxHealth = 50;
                currentHealth = maxHealth;
                healthBarSlider.maxValue = maxHealth;
                healthBarSlider.value = currentHealth;
                break;
            case 1:
                maxHealth = 100;
                currentHealth = maxHealth;
                healthBarSlider.maxValue = maxHealth;
                healthBarSlider.value = currentHealth;
                break;
        }
    }

    private void UpdateHealthBarValue()
    {
        healthBarSlider.value = currentHealth;
    }

    public void DamagePlayer(int damage)
    {
        currentHealth -= damage;
        
        UpdateHealthBarValue();

        if (currentHealth <= 0)
        {
            //Lose
        }
    }
}
