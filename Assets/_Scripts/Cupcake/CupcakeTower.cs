using UnityEngine;

/// <summary>
/// Shoot the enemy and upgrade the tower if possible
/// </summary>
public class CupcakeTower : MonoBehaviour
{
    [Header("Shooting settings")]
    public float rangeRadius = 10; //max distance the tower can shoot
    public float reloadTime = 1; //time before the tower is able to shoot again
    public GameObject projectilePrefab;
    private float elapsedTime; // the last shot

    [Header("Upgrade Settings")]
    public int upgradeLevel;
    public Sprite[] upgradeSprites;
    public bool isUpgradable = true;

    [Header("Buy and Sell settings")]
    public int initialCost;
    public int upgradingCost;
    public int sellingValue;

    private SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

   // Update is called once per frame
    void Update()
    {
        if(elapsedTime >= reloadTime)
        {
            //reset the Time
            elapsedTime = 0;

            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, rangeRadius);

            if(hitColliders.Length != 0)
            {
                float min = int.MaxValue;
                int index = -1;

                for(int i = 0; i < hitColliders.Length; i++)
                {
                    if (hitColliders[i].tag == "Enemy")
                    {
                        float distance = Vector2.Distance(hitColliders[i].transform.position, transform.position);
                        if (distance < min)
                        {
                            Debug.Log("Enemy in range");
                            index = i;
                            min = distance;
                        }
                    }
                }
                if (index == -1)
                    return;

                //Get the direction of the target
                Transform target = hitColliders[index].transform;
                Vector2 direction = (target.position - transform.position).normalized;

                //Create the Projectile
                GameObject projectile = GameObject.Instantiate(projectilePrefab, transform.position, Quaternion.identity) as GameObject;
                Debug.Log("Shooting projectiles");
                projectile.GetComponent<Projectile>().dir = direction;
            }
           
        }
        elapsedTime += Time.deltaTime;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, rangeRadius);
    }

    public void Upgrade()
    {
        if(!isUpgradable)
        {
            return;
        }

        upgradeLevel++;

        if(upgradeLevel < upgradeSprites.Length)
        {
            isUpgradable = false;
        }

        //increase the stats of the tower
        rangeRadius += 2f;
        reloadTime -= 0.5f;

        //change graphcs of the tower
       sr.sprite = upgradeSprites[upgradeLevel];
    }

    void OnMouseDown()
    {
        TradeCupcakeTower.setActiveTower(this);
    }
}
