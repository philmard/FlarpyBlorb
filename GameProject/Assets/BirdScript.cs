using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody; // reference for rigidbody2D
    public float flapStrength;
    public LogicScript logic;
    public bool birdIsAlive = true;
    public Animator myAnimator;
    public AudioSource flapSFX;
    public GameObject myStartScreen;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        // ++also make rigidbody = not active
        myRigidbody.Sleep();
    }

    // Update is called once per frame
    void Update()
    {
        myAnimator.SetFloat("SpeedY", myRigidbody.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) == true && birdIsAlive == true && PauseMenu.gameIsPaused == false) 
        {
            myRigidbody.velocity = Vector2.up * flapStrength;
            flapSFX.Play();

            // also disable the start text (w/ the first 'Space' press)
            logic.gameStart();
            // and make the bird have gravity
            myRigidbody.WakeUp();
        }
        
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        birdIsAlive = false;
    }

    private void makeBodyActive() //++
    {

    }
}
