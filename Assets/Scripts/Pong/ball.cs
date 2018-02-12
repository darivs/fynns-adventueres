using UnityEngine;
using System.Collections;

public class ball : MonoBehaviour
{


    public float ballVelocity = 500;
    Rigidbody rb;
    bool isPlay;
    int randInt;

    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody> ();
        randInt = Random.Range(1, 3);
    }


    void Update()
    {
        if (Input.GetMouseButton(0) == true && isPlay == false)
        {
            transform.parent = null;
            isPlay = true;
            rb.isKinematic = false;
            if (randInt == 1)
            {
                rb.AddForce(new Vector3(ballVelocity, ballVelocity));
            }
            if (randInt == 2)
            {
                rb.AddForce(new Vector3(-ballVelocity, -ballVelocity));
            }
        }
    }
}

 