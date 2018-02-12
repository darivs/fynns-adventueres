using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public float PlayerSpeed = 1;
    public Vector3 PlayerPos;
	
	// Update is called once per frame
	void Update ()
    {
        float yPos = gameObject.transform.position.y + (Input.GetAxis("Vertical") * PlayerSpeed);
        PlayerPos = new Vector3 (-9.5f,Mathf.Clamp(yPos,-5, 5),0);
        gameObject.transform.position = PlayerPos;
	}
}
