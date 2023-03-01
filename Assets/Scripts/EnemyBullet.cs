using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float r = Random.Range(-30, +30);
        GameObject target = GameObject.Find("fighter");
        Vector3 face = this.transform.up;
        Vector3 direct = target.transform.position - transform.position;
        float angle = Vector3.SignedAngle(face, direct, Vector3.forward);
        transform.Rotate(0, 0, angle + r);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
