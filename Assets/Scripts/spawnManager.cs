using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spawnManager : MonoBehaviour
{
    public const int maxPlanes = 10; 
    public int numberOfPlanes = 0;
    public GameObject planePrefab; //set in unity
    
    public int mPlanesTouched = 0;
    public Text mEnemyTouched = null;
   
    public int mPlanesDestroyed = 0;
    public Text mEnemyDestroyed = null;

    public Text mEggsOnScreen = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
#if UNITY_EDITOR
            // Application.Quit() does not work in the editor so
            // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }

        GameObject[] projectiles = GameObject.FindGameObjectsWithTag("Finish");

        mEggsOnScreen.text = "Eggs(" + projectiles.Length + ")";

        if (numberOfPlanes < maxPlanes)
        {
            GameObject e = Instantiate(planePrefab);

            Vector3 pos;
            pos.x = Random.Range(-178f, 178f);
            pos.y = Random.Range(-100f, 100f);
            pos.z = 0;
            e.transform.localPosition = pos;

            ++numberOfPlanes;
        }
        mEnemyDestroyed.text = "Planes destroyed(" + mPlanesDestroyed + ")";
    }
    public void EnemyDestroyed()
    {
        --numberOfPlanes;
    }
}
