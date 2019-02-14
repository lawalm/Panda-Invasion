using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacingCupcakeTower : MonoBehaviour
{
    private GameController gc;
    // Start is called before the first frame update
    void Start()
    {
        gc = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Get the mouse position
        float x = Input.mousePosition.x;
        float y = Input.mousePosition.y;

        /* Place the Cupcake Tower where the mouse is, transformed in game coordinates
         * from the Main Camera. Since the Camera is placed at -10 and we want the
         * tower to be at -3, we need to use 7 as z-axis coordinate */
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(x, y, 1));

        //If the player clicks, the second condition checks if the current position is
        //within an area where Cupcake towers can be placed
        if (Input.GetMouseButtonDown(0) && gc.CanPlaceCake())
        {
            //Enabling again the main Cupcake tower script, so to make it operative
            GetComponent<CupcakeTower>().enabled = true;
            //Place a collider on the Cupcake tower
            gameObject.AddComponent<BoxCollider2D>();
            //Remove this script, so to not keeping the Cupcake Tower on the mouse
            Destroy(this);
        }
             
    }
}

