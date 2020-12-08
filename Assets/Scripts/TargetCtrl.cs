using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCtrl : MonoBehaviour
{
    // Start is called before the first frame update
    void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.tag == "bullet") // 총알 피격시 오브젝트 삭제
        {
            Debug.Log("총 맞음");
            SpawnTarget.instance.spawnTarget();
            Destroy(coll.gameObject);
            Destroy(gameObject);
        }
    }
}
