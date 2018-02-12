using UnityEngine;
using System.Collections;

public class spawnfood : MonoBehaviour
{
    // Food Prefab
    public GameObject foodPrefab;
    public GameObject Player;
    public GameObject tailprefab;

    // Borders
    public Transform borderTop;
    public Transform borderBottom;
    public Transform borderLeft;
    public Transform borderRight;

    // Use this for initialization
    void Awake()
    {
        // Spawn food every 4 seconds, starting in 3
        InvokeRepeating("Spawn", 3, 4);
    }

    // Spawn one piece of food
    void Spawn()
    {
        // x position between left & right border
        int x = (int)Random.Range(borderLeft.position.x + 0.5f,
                                  borderRight.position.x -0.5f);

        // y position between top & bottom border
        int y = (int)Random.Range(borderBottom.position.y + 0.5f,
                                  borderTop.position.y - 0.5f);

        while (x == Player.transform.position.x && x == tailprefab.transform.position.x)
        {
            x = (int)Random.Range(borderLeft.position.x + 0.5f,
                                  borderRight.position.x - 0.5f);
        }

        while (y == Player.transform.position.y && y == tailprefab.transform.position.y)
        {
            y = (int)Random.Range(borderBottom.position.y + 0.5f,
                                  borderTop.position.y - 0.5f);
        }

        // Instantiate the food at (x, y)
        Instantiate(foodPrefab,
                    new Vector2(x, y),
                    Quaternion.identity); // default rotation
    }
}
