using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PipeMiddleScript : MonoBehaviour
{
    public LogicScript logic;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>(); // PipeMiddleScript can "talk" to LogicScript
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            if (!logic.gameOverScreen.activeSelf) // dont addScore if bird is dead
            {
                logic.addScore(1);
            }
            else
            {
                Debug.Log("Can't add score, bird is dead!");
            }
            
            if (logic.playerScore > logic.highScore)
            {
                logic.updateHighScore(logic.playerScore);
            }
        }
        
    }
}
