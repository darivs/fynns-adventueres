using UnityEngine;
using System.Collections;

public class food : MonoBehaviour {

    public float speed = 2;
    public GameObject deathscreen;
    public GameObject leben1;
    public GameObject leben2;
    public GameObject leben3;
    public Rigidbody2D rb;
    public Rigidbody2D rbb;
    public TextMesh score;
    int sco = 0;
    public GameObject buchstabe;
    int debug = 0;
    int leben = 4;
    // Use this for initialization
    void Start ()
    {
        deathscreen.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
        rbb.isKinematic = true;
        speed *= -1;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        //rb.AddForce(transform.forward * speed);
        rb.velocity = new Vector2(0, speed);
	}
    void Update()
    {
        score.text = sco.ToString();
        if (sco == 15)
        {
            while (debug == 0)
            {
                buchstabe.transform.position = new Vector2(Random.Range(-8, 8), 6);
                rbb.isKinematic = false;
                debug++;
            }
        }
        if (leben == 3)
        {
            leben3.SetActive(false);
        }
        else if (leben == 2)
        {
            leben2.SetActive(false);
        }
        else if(leben == 1)
        {
            leben1.SetActive(false);
        }

        if (leben == 0)
        {
            PlayerPrefs.SetInt("previousLevel", Application.loadedLevel);
            Application.LoadLevel("Game Over");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        int random = Random.Range(-8, 8);
        if ((random % 2) != 0)
        {
            random--;
        }
        if (other.tag == "player")
        {
            gameObject.transform.position = new Vector2(random,5);
            sco++;
        }
        if (other.tag == "ground")
        {
            gameObject.transform.position = new Vector2(random, 5);
            leben--;
        }
    }
}
