using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesDisplay : MonoBehaviour {
    public Text livesText;

	// Update is called once per frame
	void Update ()
    {
        SetLivesText();
    }

    public void SetLivesText()
    {
        LevelCreator Lives = new LevelCreator();
        livesText.text = "Lives: " + LevelCreator.CurLives;

    }
}
