using UnityEngine;
using System.Collections;

public class SimpleEnemy : MonoBehaviour {

    public float velocity = 1f;
    public bool colliding;
    public bool touched;

    public Transform sightStart;
    public Transform sightEnd;

    public LayerMask whatToCollide;
    public LevelManager levelManager;
    public GameObject deathParticle;

    [HideInInspector]
    private bool stomped = false;
    
    private Rigidbody2D rb2d;
    private Animator anim;

    void Start() {

        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        levelManager = FindObjectOfType<LevelManager>();

    }

    void Update()
    {
        if (stomped == false)
        {
            rb2d.velocity = new Vector2(-velocity, rb2d.velocity.y);
        }

        colliding = Physics2D.Linecast(sightStart.position, sightEnd.position, whatToCollide);

        if (colliding)
        {
            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
            velocity *= -1;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Fynn killed by an Enemy");
            levelManager.RespawnPlayer();
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Spit")
        {
            Debug.Log("Enemy Death");
            Dies();
        }
    }

    void Dies()
    {
        Instantiate(deathParticle, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
