using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCreator : MonoBehaviour
{
    public GameObject playerBall;
    public GameObject losePrefab;
    public GameObject winPrefab;
    public GameObject floor0;
    public GameObject floor1;
    public GameObject floor2;
    public GameObject floor3;
    public Dictionary<int, GameObject> floorMap = new Dictionary<int, GameObject>();
    public Dictionary<int, Level> levels = new Dictionary<int, Level>();
    public int CurrentLevel;

    void Start()
    {
        // Add all the levels by reference for quick reference
        levels.Add(1, new Level1());

        // Add all the floor prefabs to dictionary for quick reference
        floorMap.Add(0, floor0);
    }

    public bool LoadLevel(int levelNumber)
    {
        try
        {
            Level curLevel = levels[levelNumber];
            int[,] levelLayout = curLevel.GetLayout();
            CurrentLevel = levelNumber;

            // Clear Current Level
            GameObject[] rmFloor = GameObject.FindGameObjectsWithTag("Floor");
            GameObject[] rmBall = GameObject.FindGameObjectsWithTag("PlayerBall");
            GameObject[] rmLoseTrigger = GameObject.FindGameObjectsWithTag("Lose");
            GameObject[] rmWinTrigger = GameObject.FindGameObjectsWithTag("Win");

            foreach (var x in rmFloor) // Kill Floor
            {
                Destroy(x);
            }

            foreach (var y in rmBall) // Kill Ball
            {
                Destroy(y);
            }

            foreach (var z in rmLoseTrigger) // Kill Lose Trigger
            {
                Destroy(z);
            }

            foreach (var a in rmWinTrigger) // Kill Win Trigger
            {
                Destroy(a);
            }

            // Create Floor + Triggers
            for (var i = 0; i < levelLayout.GetLength(0); i++) // Width
            {
                for (var j = 0; j < levelLayout.GetLength(1); j++) // Height
                {
                    // Create Floor
                    GameObject currentPrefab = floorMap[levelLayout[i, j]]; // Use the key in the levelLayout and get the correct Prefab
                    Vector3 pos = new Vector3(i, 0f, j);
                    Instantiate(currentPrefab, pos, Quaternion.identity);

                    // Create Triggers below Floor
                    if (i == curLevel.GetEndX() && j == curLevel.GetEndY())
                    {
                        Instantiate(winPrefab, new Vector3(i, -2f, j), Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(losePrefab, new Vector3(i, 2f, j), Quaternion.identity);
                    }
                }
            }

            // Create Ball
            var startXPos = curLevel.GetStartX() + .5f;
            var startYPos = curLevel.GetStartY() + .5f;
            Instantiate(playerBall, new Vector3(startXPos, 1, startYPos), Quaternion.identity);

            // Set Camera
            // TODO: Zoom out enough to show entire gameboard.

            return true; // Indicate when and if it was successful.
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }
}
