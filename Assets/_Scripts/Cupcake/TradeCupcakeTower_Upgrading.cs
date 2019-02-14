using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class TradeCupcakeTower_Upgrading : TradeCupcakeTower
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentActiveTower == null)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        //Check if the player can afford to upgrade the tower
        if (currentActiveTower.isUpgradable && currentActiveTower.upgradingCost <= sugarMeter.getSugarAmount())
        {
            //The payment is executed and the sugar removed from the player
            sugarMeter.ChangeSugar(-currentActiveTower.upgradingCost);
            //The tower is upgraded
            currentActiveTower.Upgrade();
        }
    }
}
