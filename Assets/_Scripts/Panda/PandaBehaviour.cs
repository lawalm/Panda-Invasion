using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Handle the panda's path throught the waypoints and health
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class PandaBehaviour : MonoBehaviour
{
    [Header("Panda Characteristics")]
    public float speed = 1.0f;
    public int startingHealth = 100;
    public int currentHealth = 100;
    public Slider healthSlider;
    public AudioSource hitAudio;
    public int hitValue = 20; //sugar increase

    private Rigidbody2D r2b;
    private Animator anim;
    private Waypoint currentWaypoint;
    GameController gm;
    public int cakeEatenPerBiteDamage = 20;

    //Hash representations of the Triggers of the Animator controller of the Panda
    private int AnimDieTriggerHash = Animator.StringToHash("DieTrigger");
    private int AnimHitTriggerHash = Animator.StringToHash("HitTrigger");
    private int AnimEatTriggerHash = Animator.StringToHash("EatTrigger");
    //Private constant under which a waypoint is considered reached
    private const float changeDist = 0.001f;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameController._instance;

        currentHealth = startingHealth;
        r2b = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        hitAudio = GetComponent<AudioSource>();

        currentWaypoint = gm.firstWaypoint;

        //Calculate the distance between the Panda and the waypoint that the Panda is moving towards
        float dist = Vector2.Distance(transform.position, currentWaypoint.GetPosition());

        //If the waypoint is considered reached because below the threshold of the constant changeDist
        //the counter of waypoints is increased, otherwise the Panda moves towards the waypoint
        if (dist <= changeDist)
        {
            currentWaypoint = currentWaypoint.GetNextWaypoint();
        }
        else
        {
            MoveTowards(currentWaypoint.GetPosition());
        }
    }

    public void SetSpeed(float currentSpeed)
    {
        speed = currentSpeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       if(currentWaypoint == null)
        {   
            anim.SetTrigger(AnimEatTriggerHash);
            
            return;
        }

        //Calculate the distance between the Panda and the waypoint that the Panda is moving towards
        float dist = Vector2.Distance(transform.position, currentWaypoint.GetPosition());

        //If the waypoint is considered reached because below the threshold of the constant changeDist
        //the counter of waypoints is increased, otherwise the Panda moves towards the waypoint
        if (dist <= changeDist)
        {
            currentWaypoint = currentWaypoint.GetNextWaypoint();
        }
        else
        {
            MoveTowards(currentWaypoint.GetPosition());
        }
    }

    //Function that based on the speed of the Panda makes it moving towards the destination point, specified as Vector3
    private void MoveTowards(Vector3 destination)
    {
        float step = speed * Time.fixedDeltaTime;
        r2b.MovePosition(Vector3.MoveTowards(transform.position, destination, step));
    }

    private void GotHit(int damage)
    {
        currentHealth -= damage;

        healthSlider.value = currentHealth;

        if(currentHealth <= 0)
        {
            currentHealth = 0;
            anim.SetTrigger(AnimDieTriggerHash);
            gm.OneMorePandaInHeaven();
        }
        else
        {
            anim.SetTrigger(AnimHitTriggerHash);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Projectile"))
        {
            hitAudio.Play();
            GotHit(other.GetComponent<Projectile>().damage);
            SugarMeterScript.SugarInstance.ChangeSugar(hitValue);
            Destroy(other.gameObject);
        }

        if(other.gameObject.CompareTag("SugarMountain"))
        {
            gm.BiteTheCake(cakeEatenPerBiteDamage);
            //Debug.Log("Collided with " + other.gameObject);
          
        }
    }
}
