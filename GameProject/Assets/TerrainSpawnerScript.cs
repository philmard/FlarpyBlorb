using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainSpawnerScript : MonoBehaviour
{
    public GameObject terrain;
    public float spawnRate = 5;
    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        spawnTerrain();
        //Instantiate(terrain, new Vector3((float)(transform.position.x - 1.1), transform.position.y, 0), transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer = timer + Time.deltaTime; // timer counts up every frame (aneksarthto tou PC Framerate(!))
        }
        else
        {
            spawnTerrain();
            timer = 0;
        }
    }

    void spawnTerrain()
    {
        Instantiate(terrain, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
    }
}
