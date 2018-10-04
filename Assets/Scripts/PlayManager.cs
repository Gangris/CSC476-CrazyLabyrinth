using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayManager : MonoBehaviour
{
    public Button DebugButtonPlay1;
    public Text DebugText;
	// Use this for initialization
	void Start ()
	{
	    Button btn = DebugButtonPlay1.GetComponent<Button>();
        btn.onClick.AddListener(TaskDebugButtonPlay1Clicked);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void TaskDebugButtonPlay1Clicked()
    {
        DebugText.text = "Loaded Level 1";
        LevelCreator.LoadLevel(1);
    }
}
