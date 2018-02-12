using UnityEngine;
using System.Collections;

public class screen : MonoBehaviour {

    public TextMesh BotScore;
    public TextMesh PlayerScore;
    public GameObject Deathscreen;
    public GameObject PlayerScreen;
	// Use this for initialization
	void Start ()
    {
        Deathscreen.SetActive(false);
        PlayerScreen.SetActive(false);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (BotScore.text == "1")
        {
            PlayerPrefs.SetInt("previousLevel", Application.loadedLevel);
            Application.LoadLevel("Game Over");
        }

        if (PlayerScore.text == "3")
        {
            PlayerScreen.SetActive(true);
        }
	}
}
