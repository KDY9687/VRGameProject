using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : MonoBehaviour
{
    public int damage = 20;

    public float speed;

    private float ent_distance = 0.0f;

   // public GameObject flameEffect;

    public GameObject flameEffect;

    // Start is called before the first frame update

    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);

        if (ent_distance >= 10000)
            Destroy(gameObject);
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.tag == "target") // 오브젝트 삭제
        {
            CreateFlame();
            SoundManager.instance.playSound("hit");
            Destroy(gameObject);
        }
    }
    
    void CreateFlame()
    {
        GameObject flame = (GameObject)Instantiate(flameEffect, transform.position, transform.rotation);

        //Debug.Log("transform.position : " + transform.position.x + ", " + transform.position.y + ", " + transform.position.z);
        //Debug.Log("CreateFlame : " + flame);
        //Debug.Log("flame.GetComponent<ParticleSystem>().duration : " + flame.GetComponent<ParticleSystem>().duration);
        Destroy(flame, flame.GetComponent<ParticleSystem>().duration);
    }
}
