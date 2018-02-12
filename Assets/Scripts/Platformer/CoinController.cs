using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CoinController : MonoBehaviour {

    public static int points;

    public PlayerController playerCon;

    public Text pointstext;

    void Start()
    {
        playerCon = FindObjectOfType<PlayerController>();
    }

	void Update () {

        //pointstext.text = ("" + points);
	
	}
}
