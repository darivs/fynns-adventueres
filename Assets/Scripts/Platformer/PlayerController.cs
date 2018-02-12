using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed = 4, jumpForce;
    public bool right = true, collided = false;
    public Transform groundCheck, spitPoint;
    public GameObject spittle;
    public LayerMask whatIsGround;
    public LevelManager levelManager;
    public Text spitCounterText;
    public Text coinCounterText;

    public static int spitCounter = 10;
    public static int coinCounter = 0;

    public Text dJumpText;                      // UI text for avaiability of double jump

    [HideInInspector]
    private SpriteRenderer sRenderer;
    private Rigidbody2D rb2d;
    private bool isGrounded = false, jump, doubleJumped;
    private float speedInAir, stanjumpForce;

    private Color normColor;

	void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();
        levelManager = FindObjectOfType<LevelManager>();
        sRenderer = GetComponent<SpriteRenderer>();

        stanjumpForce = jumpForce;
        speedInAir = (speed / 3) * 2;
        
        normColor = sRenderer.color;
    }

    void Update()
    {
        if (isGrounded)
        {
            jumpForce = stanjumpForce;
            doubleJumped = false;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (spitCounter > 0)
            {
                Instantiate(spittle, spitPoint.position, spitPoint.rotation);
                spitCounter--;
            }
        }
        else
        {
            if (spitCounter < 10)
            {
                StartCoroutine("SpitPlus");
            }
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            jump = true;
        }

        if (Input.GetButtonDown("Jump") && !doubleJumped && !isGrounded)     
        {
            /* DoubleJump */
            sRenderer.color = new Color(0.48627f, 0.48627f, 0.48627f, 1f);
            jump = true;
            doubleJumped = true;
            jumpForce *= 0.75f;
        }

        if (!isGrounded) { speed = speedInAir; }
        else { speed = (speedInAir / 2) * 3; }

        spitCounterText.text = ("" + spitCounter);
        coinCounterText.text = ("" + coinCounter);
    }
	
	void FixedUpdate ()
    {
        /* double jump avaiable */
        if (isGrounded)
        {
            sRenderer.color = normColor;
        }

        float hor = Input.GetAxis("Horizontal");
        rb2d.velocity = new Vector2(hor * speed, rb2d.velocity.y);

        if ((hor > 0 && !right) || (hor < 0 && right))
        {
            Flip();
        }

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.15F, whatIsGround);

        if (jump)
        {
            rb2d.velocity /= 5;
            rb2d.AddForce(new Vector2(0, jumpForce));
            jump = false;
        }
        else
        {
            rb2d.velocity = new Vector2(hor * speed, rb2d.velocity.y);
        }
	}

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Coin"))
        {
            Destroy(col.gameObject);
            coinCounter += 1;
        }

        if (col.CompareTag("Portal"))
        {
            Application.LoadLevel("Level Bonus");
        }
    }

    public void Flip()
    {
        right = !right;
        Vector3 myScale = transform.localScale;
        myScale.x *= -1;
        transform.localScale = myScale;
    }

    public IEnumerator SpitPlus()
    {
        yield return new WaitForSeconds(3);

        if (spitCounter < 10)
        {
            spitCounter++;
            StopCoroutine("SpitPlus");
        }
    }
}
