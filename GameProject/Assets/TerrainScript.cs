using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainScript : MonoBehaviour
{
    //public GameObject terrain;
    public float moveSpeed = 5;
    public float deadZone = -150;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;

        if (transform.position.x < deadZone)
        {
            if (gameObject != null)
            {
                Debug.Log("Terrain Deleted");
                Destroy(gameObject);
            }
            
        }
    }
}
