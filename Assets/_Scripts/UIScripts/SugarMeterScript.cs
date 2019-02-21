using System;
using UnityEngine;
using UnityEngine.UI;

public class SugarMeterScript : MonoBehaviour
{
    public static SugarMeterScript SugarInstance = null;
    private Text sugarMeter;
    [SerializeField]private int sugarValue = 100;

    private void Awake()
    {
        SugarInstance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        sugarMeter = GetComponentInChildren<Text>();
        UpdateSugarMeter();
    }

    /// <summary>
    /// Function to incraese or decrease the amount of sugar
    /// </summary>
    /// <param name="value"></param>
    public void ChangeSugar(int value)
    {
        sugarValue += value;

        if(sugarValue < 0)
        {
            sugarValue = 0;
        }
        UpdateSugarMeter();
    }

    public int getSugarAmount()
    {
        return sugarValue;
    }

    private void UpdateSugarMeter()
    {
        // Assign the amount of sugar converted to a string to the text in the Sugar Meter
        sugarMeter.text = sugarValue.ToString();
    }
}
