using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This a test script implementing waypoint implementation 1
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class PandaBehaviour : MonoBehaviour
{
    [Header("Panda Characteristics")]
    public float speed = 1.0f;
    public int health = 100;

    private Rigidbody2D r2b;
    private Animator anim;
    private Waypoint currentWaypoint;
    private static GameController gm;

    //Hash representations of the Triggers of the Animator controller of the Panda
    private int AnimDieTriggerHash = Animator.StringToHash("DieTrigger");
    private int AnimHitTriggerHash = Animator.StringToHash("HitTrigger");
    private int AnimEatTriggerHash = Animator.StringToHash("EatTrigger");
    //Private constant under which a waypoint is considered reached
    private const float changeDist = 0.001f;

    // Start is called before the first frame update
    void Start()
    {
        if(gm == null)
        {
            gm = FindObjectOfType<GameController>();
        }

        r2b = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

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
            Destroy(gameObject);
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
        health -= damage;

        if(health <= 0)
        {
            anim.SetTrigger(AnimDieTriggerHash);
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
            GotHit(other.GetComponent<Projectile>().damage);
        }
    }
}
