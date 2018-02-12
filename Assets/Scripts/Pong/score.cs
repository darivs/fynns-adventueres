using UnityEngine;
using System.Collections;

public class score : MonoBehaviour {

    public TextMesh CurrScore;
    public GameObject BallPref;
    public Transform PlayerObj;

    float Score;
    GameObject Ball;
	
	// Update is called once per frame
	void Update ()
    {
        Ball = GameObject.FindGameObjectWithTag("ball");
        CurrScore.text = Score.ToString();
        Debug.Log(CurrScore.text);
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ball")
        {
            Score+=1;
            //Ball.transform.position = new Vector3(PlayerObj.transform.position.x + 2, PlayerObj.transform.position.y, 0);
            (Instantiate(BallPref, new Vector3(PlayerObj.transform.position.x + 1, PlayerObj.transform.position.y, 0), Quaternion.identity) as GameObject).transform.parent = PlayerObj;
            Destroy(Ball);
        }
    }
}
