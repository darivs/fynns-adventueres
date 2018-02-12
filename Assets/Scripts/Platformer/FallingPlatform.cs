using UnityEngine;
using System.Collections;

public class FallingPlatform : MonoBehaviour {

	private Rigidbody2D rb2d;
    private Collider2D col2d;
    private SpriteRenderer sRend;
	public float fallDelay;
	
	void Start ()
    {
		rb2d = GetComponent<Rigidbody2D>();
        col2d = GetComponent<Collider2D>();
        sRend = GetComponent<SpriteRenderer>();
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("Player"))
        {
            StartCoroutine(Fall());
        }
    }

    IEnumerator Fall()
    {
        yield return new WaitForSeconds(fallDelay);
        rb2d.isKinematic = false;
        col2d.enabled = false;
        sRend.sortingOrder += 100;
        
        GetComponent<Collider2D>().isTrigger = true;
        yield return 0;
    }
}
