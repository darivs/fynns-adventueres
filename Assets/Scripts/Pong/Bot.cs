using UnityEngine;
using System.Collections;

public class Bot : MonoBehaviour {

    public float speed = 8;
    Vector3 BotPos;
    Vector3 PlayerPos;
    GameObject GameObj;

	// Update is called once per frame
	void Update ()
    {
        GameObj = GameObject.FindGameObjectWithTag("ball");
        BotPos = Vector3.Lerp (gameObject.transform.position,GameObj.transform.position, Time.deltaTime * speed);
        PlayerPos = new Vector3(-9.5f, Mathf.Clamp(BotPos.y, -5, 5), 0);
        gameObject.transform.position = new Vector3(10, PlayerPos.y,0);
    }
}
