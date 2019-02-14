using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Handle the health of the player
/// </summary>
public class HealthBarScript : MonoBehaviour
{
    public int maxHealth = 100;
    private Image fillingImage;
    private int currentHealth = 100;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        fillingImage = GetComponentInChildren<Image>();
        UpdateHealthBar();
    }

   public bool ApplyDamage(int amount)
    {
        currentHealth -= amount;

        if(currentHealth > 0)
        {
            return false;
        }
        currentHealth = 0;
        UpdateHealthBar();
        return true;
    }

    /// <summary>
    /// Calculate the percentages of the current amount of health
    /// </summary>
    private void UpdateHealthBar()
    {
        float percentage = currentHealth * 1f / maxHealth;
        fillingImage.fillAmount = percentage;
    }
}
