using UnityEngine;
using System.Collections;

public class SpitController : MonoBehaviour
{

    public float speed;

    public PlayerController player;
    public GameObject breakGlassParticle;
    public GameObject droppingCoin;

    public int spits;

    private Rigidbody2D rb2d;
    private Transform tran;

    private int number = 0;

    void Start()
    {
        spits = 10;

        rb2d = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerController>();

        if (player.right == false)
        {
            speed *= -1;
            Flip();
        }
    }

    void Update()
    {
        rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Player" && other.tag != "Spit" && other.tag != "Coin" && other.tag != "Spike" && other.tag != "navi" && other.tag != "Checkpoint")
        {
            number = Random.Range(1, 5);
            Destroy(gameObject);
            Debug.Log(number);

            if (other.tag == "Enemy")
            {
                Destroy(other.gameObject);

                if (number == 3)
                {
                    float ypos = other.transform.position.y + 2;
                    Vector3 enemyPos = new Vector3(transform.position.x, ypos, transform.position.z);
                    Instantiate(droppingCoin, enemyPos, other.transform.rotation);
                }
            }
        }

        if (other.tag == "breakable")
        {
            Destroy(other.gameObject);

            if (other.name == "Glass")
            {
                Instantiate(breakGlassParticle, other.transform.position, other.transform.rotation);
            }
        }
    }

    void Flip()
    {
        Vector3 myScaleSpit = transform.localScale;
        myScaleSpit.x *= -1;
        transform.localScale = myScaleSpit;
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
