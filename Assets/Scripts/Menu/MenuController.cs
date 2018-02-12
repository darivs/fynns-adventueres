using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Play()
    {
        Application.LoadLevel("Game Menu");
    }

    public void Options()
    {
        Application.LoadLevel("Options");
    }

    public void HowToPlay()
    {
        Application.LoadLevel("How To Play");
    }

    public void BackToMainMenu()
    {
        Application.LoadLevel("Main Menu");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
