using UnityEngine;

//moves the projectile in a given direction
public class Projectile : MonoBehaviour
{
    public int damage;
    public Vector3 dir;
    public GameObject impactEffect;
    private AudioSource audioSource;
   
    [SerializeField] float lifeDuration = 3f;
    [SerializeField] float speed = 1f;

    private Rigidbody2D r2b;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            GameObject effectIns = Instantiate(impactEffect, other.transform.position, Quaternion.identity);
            Destroy(effectIns, 2f);
        }     
    }

}
