using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
   
    public float speed;
    private Rigidbody rb;


    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
     
    }
 
    // Update is called once per frame
    void FixedUpdate () {
      
        float moveHorizontal = Input.GetAxis("Horizontal");
	    float moveVertical = Input.GetAxis("Vertical");

	    Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

	    rb.AddForce(movement * speed);
    }

    public void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.CompareTag("Win"))
        {    
            LevelCreator.LoadNextLevel();
        }

        if (c.gameObject.CompareTag("Lose")) {
            LevelCreator.CurrentLives();
            LevelCreator.RestartCurrentLevel();
        }

    }


}
