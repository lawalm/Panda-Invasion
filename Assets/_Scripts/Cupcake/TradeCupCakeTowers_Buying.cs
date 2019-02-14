using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class TradeCupCakeTowers_Buying : TradeCupcakeTower
{
    public GameObject cupcakeTowerPrefab;
    // Start is called before the first frame update
    void Start()
    {
        if (sugarMeter == null)
        {
            sugarMeter = FindObjectOfType<SugarMeterScript>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //implement the abstract function inherited from it's parent
    public override void OnPointerClick(PointerEventData eventData)
    {
        //Retrieve from the prefab which is its initial cost
        int price = cupcakeTowerPrefab.GetComponent<CupcakeTower>().initialCost;

        // Check if the player can afford to buy the tower
        if (price <= sugarMeter.getSugarAmount())
        {
            //Payment succeeds, and the cost is removed from the player's sugar
            sugarMeter.ChangeSugar(-price);
            //A new Cupcake tower is created
            GameObject newTower = Instantiate(cupcakeTowerPrefab);
            //The new Cupcake tower is also assigned as the current selection
            currentActiveTower = newTower.GetComponent<CupcakeTower>();
        }
    }
}
