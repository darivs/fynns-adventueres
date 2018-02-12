using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Pong()
    {
        Application.LoadLevel("game");
    }
    public void Snake()
    {
        Application.LoadLevel("snakefull");
    }
    public void CatchIt()
    {
        Application.LoadLevel("auffangspiel");
    }
    public void Platformer()
    {
        Application.LoadLevel("Level 1");
    }
}
