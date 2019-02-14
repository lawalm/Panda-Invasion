using UnityEngine;

//moves the projectile in a given direction
public class Projectile : MonoBehaviour
{
    public int damage;
    public Vector3 dir;
    [SerializeField] float lifeDuration;
    [SerializeField] float speed = 1f;

    private Rigidbody2D r2b;

    // Start is called before the first frame update
    void Start()
    {
        r2b = GetComponent<Rigidbody2D>();
        //Normalize the direction
        dir = dir.normalized;

        //fix the rotation
        float angle = Mathf.Atan2(-dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        //set the time for self destruction
        Destroy(gameObject, lifeDuration);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        r2b.MovePosition(transform.position += dir * Time.fixedDeltaTime * speed);
    }
}
