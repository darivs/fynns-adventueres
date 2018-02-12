using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class snake : MonoBehaviour {

    public GameObject canvas;
    Vector2 dir = new Vector2(0,0.65f);
    List<Transform> tail = new List<Transform>();
    bool ate = false;
    int prevrot = 0;
    // Tail Prefab
    public GameObject tailPrefab;
    // Use this for initialization
    void Awake () {
        InvokeRepeating("Move", 1f, 0.2f);
        canvas.SetActive(false);
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        // Move in a new Direction?
        if (Input.GetKey(KeyCode.RightArrow) && prevrot != 3)
        {
            dir = new Vector2(0.65f, 0);
            prevrot = 1;
        }
                    
        else if (Input.GetKey(KeyCode.DownArrow) && prevrot != 0)
        {
            dir = new Vector2(0, -0.65f);
            prevrot = 2;
        }
              // '-up' means 'down'
        else if (Input.GetKey(KeyCode.LeftArrow) && prevrot != 1)
        {
            dir = new Vector2(-0.65f, 0);
            prevrot = 3;
        }
             // '-right' means 'left'
        else if (Input.GetKey(KeyCode.UpArrow) && prevrot != 2)
        {
            dir = new Vector2(0, 0.65f);
            prevrot = 0;
        }

        
        
    }
    void Move()
    {
        // Save current position (gap will be here)
        Vector2 v = transform.position;

        // Move head into new direction (now there is a gap)
        transform.Translate(dir);

        // Ate something? Then insert new Element into gap
        if (ate)
        {
            Debug.Log("hello");
            // Load Prefab into the world
            GameObject g = (GameObject)Instantiate(tailPrefab,
                                                  v,
                                                  Quaternion.identity);

            // Keep track of it in our tail list
            tail.Insert(0, g.transform);

            // Reset the flag
            ate = false;
        }
        // Do we have a Tail?
        else if (tail.Count > 0)
        {
            // Move last Tail Element to where the Head was
            tail.Last().position = v;

            // Add to front of list, remove from the back
            tail.Insert(0, tail.Last());
            tail.RemoveAt(tail.Count - 1);
        }
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        // Food?
        if (coll.tag == "food")
        {
            Debug.Log("");
            // Get longer in next Move call
            ate = true;

            // Remove the Food
            Destroy(coll.gameObject);
        }
        // Collided with Tail or Border
        else {
            // ToDo 'You lose' screen
            PlayerPrefs.SetInt("previousLevel", Application.loadedLevel);
            Application.LoadLevel("Game Over");
            Time.timeScale = 0;
        }
    }

}
