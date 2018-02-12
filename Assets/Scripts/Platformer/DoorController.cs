using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour {

    public GameObject key;
    public Sprite door_open;

    private bool open;

	void Start ()
    {
	
	}
	
	void Update ()
    {
	
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            GetComponent<Collider2D>().isTrigger = true;
            GetComponent<SpriteRenderer>().sprite = door_open;
        }
    }
}
