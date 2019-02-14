using System.Collections;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private Animator anim;
    [Range(1, 10f)]public float speed = 1.0f;
    private Waypoint currentWaypoint;
    private const float changeDist = 0.0001f;

    private static GameController gm;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        if(gm == null)
        {
            gm = FindObjectOfType<GameController>();
        }

        rb2D = GetComponent<Rigidbody2D>();

        //Get the first waypoint from the Game Manager
        currentWaypoint = gm.firstWaypoint;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       if(currentWaypoint == null)
        {
            Destroy(gameObject);
            return;
        }

        float dist = Vector2.Distance(transform.position, currentWaypoint.GetPosition());

        if (dist <= changeDist)
        {
            currentWaypoint = currentWaypoint.GetNextWaypoint();
            //RotateIntoMoveDirection();
        }
        else
        {
            MoveTowards(currentWaypoint.GetPosition());
        }
    }

    private void MoveTowards(Vector2 destination)
    {
        float step = speed * Time.fixedDeltaTime;
        rb2D.MovePosition(Vector2.MoveTowards(transform.position, destination, step));
       // transform.LookAt(destination);
    }

    private void RotateIntoMoveDirection(Vector2 destination)
    {
       
        float step = speed * Time.fixedDeltaTime;
        rb2D.MovePosition(Vector2.MoveTowards(transform.position, destination, step));
      
    }
}
