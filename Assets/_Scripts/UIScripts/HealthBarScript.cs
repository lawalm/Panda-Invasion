using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Handle the health of the player
/// </summary>
public class HealthBarScript : MonoBehaviour
{
    public int maxHealth = 100;
    private Slider healthSilder;
    private int currentHealth = 100;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthSilder = GetComponent<Slider>();        
    }

    public bool ApplyDamage(int amount)
    {
        currentHealth -= amount;

        healthSilder.value = currentHealth;

        if(currentHealth > 0)
        {
            return false;
        }
        currentHealth = 0;
        return true;
    }
}
