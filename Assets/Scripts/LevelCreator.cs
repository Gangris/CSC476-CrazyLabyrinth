using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private static Dictionary<int, GameObject> _floorMap = new Dictionary<int, GameObject>();
    private static Dictionary<int, Level> _levels = new Dictionary<int, Level>();
    private static Dictionary<string, GameObject> _keyItems = new Dictionary<string, GameObject>();
    private static int _currentLevel;

    void Start()
    {
        // Add key items to easily access them later
        _keyItems.Add("PlayerBall", PlayerBall);
        _keyItems.Add("Lose", LosePrefab);
        _keyItems.Add("Win", WinPrefab);

        // Add all the levels by reference for quick reference. We keep levels lightweight on purpose.
        _levels.Add(1, new Level1());

        // Add all the floor prefabs to dictionary for quick reference
        _floorMap.Add(0, Floor0);
        _floorMap.Add(1, Floor1);
        _floorMap.Add(2, Floor2);
        _floorMap.Add(3, Floor3);
        _floorMap.Add(4, Floor4);
        _floorMap.Add(5, Floor5);
        _floorMap.Add(6, Floor6);
        _floorMap.Add(7, Floor7);
        _floorMap.Add(8, Floor8);
        _floorMap.Add(9, Floor9);
        _floorMap.Add(10, Floor10);
        _floorMap.Add(11, Floor11);
        _floorMap.Add(12, Floor12);
        _floorMap.Add(13, Floor13);
        // Need to add floormaps with holes in them
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
                Vector3 pos = new Vector3(j, 0f, -i);
                Instantiate(currentPrefab, pos, Quaternion.identity);

                //// Create Triggers below Floor
                if (i == curLevel.GetEndX() && j == curLevel.GetEndY())
                {
                    Instantiate(_keyItems["Win"], new Vector3(i, -2f, j), Quaternion.identity);
                }
                else
                {
                    Instantiate(_keyItems["Lose"], new Vector3(i, -2f, j), Quaternion.identity);
                }
            }
        }

        // Create Ball
        var startXPos = curLevel.GetStartX();
        var startYPos = -(curLevel.GetStartY());
        Instantiate(_keyItems["PlayerBall"], new Vector3(startXPos, 1, startYPos), Quaternion.identity);

        // Set Camera
        // TODO: Zoom out enough to show entire gameboard.

        return true; // Indicate when and if it was successful.
    }
}
