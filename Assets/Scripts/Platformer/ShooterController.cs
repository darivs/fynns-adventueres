using UnityEngine;
using System.Collections;

public class ShooterController : MonoBehaviour {

    public GameObject arrow;
    public Transform shootPoint;

	void Start ()
    {
        
	}
	
	void Update ()
    {
        StartCoroutine("ShootedArrow");
    }

    IEnumerator ShootedArrow()
    {
        yield return new WaitForSeconds(5);
        Instantiate(arrow, shootPoint.position, shootPoint.rotation);
        StopCoroutine("ShootedArrow");
    }
}
