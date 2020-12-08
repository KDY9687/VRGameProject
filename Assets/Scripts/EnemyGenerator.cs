using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    private float birthTime;
    public GameObject Enemy;
    // Start is called before the first frame update
    void Start()
    {
        birthTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        birthTime += Time.deltaTime;
        if (birthTime >= 5f)
        {
            Instantiate(Enemy, this.transform);
            birthTime = 0f;
        }
    }
}
