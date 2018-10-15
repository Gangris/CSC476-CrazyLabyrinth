using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayManager : MonoBehaviour
{
    public Button DebugButtonPlay1;
    public Text DebugText;

    private int internalCount;
	// Use this for initialization
	void Start ()
	{
	    Button btn = DebugButtonPlay1.GetComponent<Button>();
        btn.onClick.AddListener(TaskDebugButtonPlay1Clicked);
	}
	
	// Update is called once per frame
	void Update () {
	    DebugText.text = "Loaded Level " + LevelCreator.CurrentLevel;
    }

    void TaskDebugButtonPlay1Clicked()
    {
        LevelCreator.LoadLevel(++internalCount);
    }
}
