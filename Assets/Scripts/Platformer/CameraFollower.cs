using UnityEngine;
using System.Collections;

public class CameraFollower : MonoBehaviour
{

    [SerializeField]
    private float yMax;
    [SerializeField]
    private float xMax;
    [SerializeField]
    private float xMin;
    [SerializeField]
    private float yMin;

    private Transform target;

    void Start()
    {
        target = GameObject.Find("Player").transform;

    }

    // Update is called once per frame
    void LateUpdate()
    {
        //if (transform.position.x > xMin)
        //{
        //    xMin = transform.position.x;
        //}

        //if (transform.position.x < xMin)
        //{
        //    xMin = transform.position.x;
        //}

        transform.position = new Vector3(Mathf.Clamp(target.position.x + 5, xMin, xMax), Mathf.Clamp(target.position.y -1, yMin, yMax), transform.position.z);
    }
}
