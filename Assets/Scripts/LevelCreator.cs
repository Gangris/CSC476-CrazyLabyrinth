using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class LevelCreator : MonoBehaviour
{
    public GameObject PlayerBall;
    public GameObject LosePrefab;
    public GameObject WinPrefab;
    public GameObject Floor0;
    public GameObject Floor1;
    public GameObject Floor2;
    public GameObject Floor3;
    public GameObject Floor4;
    public GameObject Floor5;
    public GameObject Floor6;
    public GameObject Floor7;
    public GameObject Floor8;
    public GameObject Floor9;
    public GameObject Floor10;
    public GameObject Floor11;
    public GameObject Floor12;
    public GameObject Floor13;
    public GameObject FloorHole0;
    public GameObject FloorHole1;
    public GameObject FloorHole2;
    public GameObject FloorHole3;
    public GameObject FloorHole4;
    public GameObject FloorHole5;
    public GameObject FloorHole6;
    public GameObject FloorHole7;
    public GameObject FloorHole8;
    public GameObject FloorHole9;
    public GameObject FloorHole10;
    public GameObject FloorHole11;
    public GameObject FloorHole12;
    private static Dictionary<int, GameObject> _floorMap = new Dictionary<int, GameObject>();
    private static Dictionary<int, Level> _levels = new Dictionary<int, Level>();
    private static Dictionary<string, GameObject> _keyItems = new Dictionary<string, GameObject>();
    private static int _currentLevel;
    private static Vector3 camPos = new Vector3(0,5,0);

    void Start()
    {
        // Add key items to easily access them later
        _keyItems.Add("PlayerBall", PlayerBall);
        _keyItems.Add("Lose", LosePrefab);
        _keyItems.Add("Win", WinPrefab);

        // Add all the levels by reference for quick reference. We keep levels lightweight on purpose.
        _levels.Add(1, new Level1());
        _levels.Add(2, new Level2());

        // Add all the floor prefabs to dictionary for quick reference
        _floorMap.Add(1, Floor0);
        _floorMap.Add(2, Floor1);
        _floorMap.Add(3, Floor2);
        _floorMap.Add(4, Floor3);
        _floorMap.Add(5, Floor4);
        _floorMap.Add(6, Floor5);
        _floorMap.Add(7, Floor6);
        _floorMap.Add(8, Floor7);
        _floorMap.Add(9, Floor8);
        _floorMap.Add(10, Floor9);
        _floorMap.Add(11, Floor10);
        _floorMap.Add(12, Floor11);
        _floorMap.Add(13, Floor12);
        _floorMap.Add(14, Floor13);
        _floorMap.Add(-1, FloorHole0);
        _floorMap.Add(-2, FloorHole1);
        _floorMap.Add(-3, FloorHole2);
        _floorMap.Add(-4, FloorHole3);
        _floorMap.Add(-5, FloorHole4);
        _floorMap.Add(-6, FloorHole5);
        _floorMap.Add(-7, FloorHole6);
        _floorMap.Add(-8, FloorHole7);
        _floorMap.Add(-9, FloorHole8);
        _floorMap.Add(-10, FloorHole9);
        _floorMap.Add(-11, FloorHole10);
        _floorMap.Add(-12, FloorHole11);
        _floorMap.Add(-13, FloorHole12);
    }

    void FixedUpdate()
    {
        transform.position = camPos;
    }

    public static bool LoadLevel(int levelNumber)
    {
        Level curLevel = _levels[levelNumber];
        int[,] levelLayout = curLevel.GetLayout();
        _currentLevel = levelNumber;

        // Clear Current Level
        GameObject[] rmFloor = GameObject.FindGameObjectsWithTag("Floor");
        GameObject[] rmBall = GameObject.FindGameObjectsWithTag("GameBall");
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
                GameObject currentPrefab = _floorMap[levelLayout[i, j]]; // Use the key in the levelLayout and get the correct Prefab
                Vector3 pos = new Vector3(j, 3f, -i);
                Instantiate(currentPrefab, pos, Quaternion.identity);

                //// Create Triggers below Floor
                if (i == curLevel.GetEndX() && j == curLevel.GetEndY())
                {
                    Instantiate(_keyItems["Win"], new Vector3(i, 1f, -j), Quaternion.identity);
                }
                else
                {
                    Instantiate(_keyItems["Lose"], new Vector3(i, 1f, -j), Quaternion.identity);
                }
            }
        }

        // Create Ball
        var startXPos = curLevel.GetStartX();
        var startYPos = -(curLevel.GetStartY());
        Instantiate(_keyItems["PlayerBall"], new Vector3(startXPos, 3.5f, startYPos), Quaternion.identity);

        // Move Camera to center on board
        var camX = (float)(levelLayout.GetLength(0) - 1) / 2f;
        var camY = -(float)(levelLayout.GetLength(1) - 1) / 2f;
        camPos = new Vector3(camX,5,camY);

        return true; // Indicate when and if it was successful.
    }
}
