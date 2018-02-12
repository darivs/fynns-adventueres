using UnityEngine;
using System.Collections;

public class pausemenucatch : MonoBehaviour {

    public GameObject PauseUI;
    bool pause = false;

    void Start()
    {
        PauseUI.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause = !pause;
        }
        if (pause)
        {
            PauseUI.SetActive(true);
            Time.timeScale = 0;
        }
        if (!pause)
        {
            PauseUI.SetActive(false);
            Time.timeScale = 1;
        }
    }
    public void Resume()
    {
        pause = false;
    }
    public void Restart()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
