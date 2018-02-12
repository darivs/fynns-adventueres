using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelManager : MonoBehaviour {

    public GameObject currentCheckpoint;

    private PlayerController player;

    public GameObject deathParticle;
    public GameObject respawnParticle;

    public Text livesText;
    public static int lives = 3;

    public float respawnDelay;

    void Start ()
    {
        lives = 3;
        player = FindObjectOfType<PlayerController>();
    }
	
	void Update ()
    {
        livesText.text = ("" + lives);	
	}

    public void RespawnPlayer()
    {
        StartCoroutine("RespawnPlayerCo");
    }

    public IEnumerator RespawnPlayerCo()
    {
        Instantiate(deathParticle, player.transform.position, player.transform.rotation);
        player.enabled = false;
        player.GetComponent<Renderer>().enabled = false;
        player.GetComponent<Collider2D>().enabled = false;

        yield return new WaitForSeconds(respawnDelay);

        if (lives > 0)
        {
            lives--;

            Debug.Log("Player respawn");
            player.transform.position = currentCheckpoint.transform.position;
            player.enabled = true;
            player.GetComponent<Renderer>().enabled = true;
            player.GetComponent<Collider2D>().enabled = true;

            Instantiate(respawnParticle, player.transform.position, player.transform.rotation);
        }
        else
        {
            Debug.Log("Level failed");

            PlayerPrefs.SetInt("previousLevel", Application.loadedLevel);
            Application.LoadLevel("Game Over");
        }
    }
}
