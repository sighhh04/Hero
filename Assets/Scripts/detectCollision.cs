using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public int health = 4;
    public spawnManager mSpawnController = null;

    // Start is called before the first frame update
    void Start()
    {
        mSpawnController = FindFirstObjectByType<spawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            Destroy(other.gameObject);
            health--;
           
            float r = gameObject.GetComponent<Renderer>().material.color.r;
            float g = gameObject.GetComponent<Renderer>().material.color.g;
            float b = gameObject.GetComponent<Renderer>().material.color.b;
            float transparent = gameObject.GetComponent<Renderer>().material.color.a;
            transparent -= .25f;

            gameObject.GetComponent<Renderer>().material.color = new Color(r, g, b, transparent);
        }
        if (health == 0)
        {
            Destroy(gameObject);
            mSpawnController.EnemyDestroyed();
            mSpawnController.mPlanesDestroyed++;
        } 
    }

}
