using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class TradeCupcakeTower : MonoBehaviour, IPointerClickHandler
{
    protected static CupcakeTower currentActiveTower;
    protected static SugarMeterScript sugarMeter;

    void Start()
    {
        if(sugarMeter == null)
        {
            sugarMeter = FindObjectOfType<SugarMeterScript>();
        }
    }

    void Update()
    {

    }

    // Static function that allows other scripts to assign the new/current selected tower
    public static void setActiveTower(CupcakeTower cupcakeTower)
    {
        currentActiveTower = cupcakeTower;
    }

    // Abstract function triggered when one of the trading buttons is pressed, however the
    // implementation is specific for each trade operation.
    public abstract void OnPointerClick(PointerEventData eventData);

}
