using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {

    public float speed = 5;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x - (1 * speed), gameObject.transform.position.y);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x + (1 * speed), gameObject.transform.position.y);
        }
    }
}
