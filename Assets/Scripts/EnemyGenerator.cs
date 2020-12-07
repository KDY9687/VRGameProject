using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    private float birthTime;
    public GameObject Enemy;
    private float spawnTime;
    // Start is called before the first frame update
    void Start()
    {
        birthTime = 0f;
        spawnTime = Random.Range(5f, 30f);
    }

    // Update is called once per frame
    void Update()
    {
        birthTime += Time.deltaTime;
        if (birthTime >= spawnTime)
        {
            Instantiate(Enemy, this.transform);
            birthTime = 0f;
            spawnTime = Random.Range(15f, 30f);
            SoundManager.instance.playSound("ZombieSound");
        }
    }
}
