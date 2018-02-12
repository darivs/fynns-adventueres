using UnityEngine;
using System.Collections;

public class GOMenuController : MonoBehaviour {
    
    public int lastLevel = Application.loadedLevel;

	void Start ()
    {
	
	}
	void Update ()
    {
	
	}

    public void Restart()
    {
        int lastLevel = PlayerPrefs.GetInt("previousLevel");
        Application.LoadLevel(lastLevel);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void BackToMainMenu()
    {
        Application.LoadLevel("Main Menu");
    }
}
