using UnityEngine;
using System.Collections;

public class ArrowController : MonoBehaviour {

    public float speed;
    public LevelManager levelManager;

    private Rigidbody2D rb2d;

    void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();
        levelManager = FindObjectOfType<LevelManager>();
    }
	
	void Update ()
    {
        rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            levelManager.RespawnPlayer();
            Destroy(gameObject);
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void OnIsInvisible()
    {
        Destroy(gameObject);
    }
}
