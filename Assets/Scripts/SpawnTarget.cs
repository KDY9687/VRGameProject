using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTarget : MonoBehaviour
{
    // Start is called before the first frame update
    public static SpawnTarget instance;

    public GameObject target;
    float x, y, z;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        spawnTarget();
        spawnTarget();
        spawnTarget();
    }

    // Update is called once per frame
    public void spawnTarget()
    {
        x = Random.Range(-20f, 20f);
        y = 0.5f;
        z = Random.Range(50f, 200f);
        Instantiate(target, new Vector3(x, y, z), target.gameObject.transform.rotation);
    }
}
