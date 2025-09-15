// MeteorSpawnerCtrl

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawnerCtrl : MonoBehaviour
{
    public float spawnPos;
    public GameObject meteor;
    public GameObject newMeteor;
    public float width;
    public float height;

    // Start is called before the first frame update
    void Start()
    {
        width = Camera.main.aspect * Camera.main.orthographicSize;
        height = Camera.main.orthographicSize;
        InvokeRepeating("SpawnMeteor", 0, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnMeteor()
    {
        spawnPos = Random.Range(-height * 2, width * 2);
        if (spawnPos < 0)
        {
            newMeteor = Instantiate(meteor, new Vector2((width + 1) * (Random.Range(0, 2) * 2 - 1), spawnPos + height), transform.rotation);
            newMeteor.GetComponent<MeteorCtrl>().sideVertical = true;
        }
        else
        {
            newMeteor = Instantiate(meteor, new Vector2(spawnPos - height * Camera.main.aspect, (height + 1) * (Random.Range(0, 2) * 2 - 1)), transform.rotation);
            newMeteor.GetComponent<MeteorCtrl>().sideVertical = false;
        }
    }
}
////////////////////////////////////////////////////////////////////////////////
