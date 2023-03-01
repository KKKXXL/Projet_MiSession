using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject bullet;
    float fireSpe = 0f;
    public float fireSpeed = 0.3f;

    public float faceChangeSpeed = 30f;
    public float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject target = GameObject.Find("/fighter");
        Vector3 face = this.transform.up;
        Vector3 pst = target.transform.position;
        Vector3 pst_e = this.transform.position;
        Vector3 director = pst - pst_e;

        float angle = Vector3.SignedAngle(face, director, Vector3.forward);
        float rotateAngle = Time.deltaTime * faceChangeSpeed;
        if (angle < 0)
        {
            rotateAngle = -rotateAngle;
        }
        transform.Rotate(0, 0, rotateAngle, Space.Self);

        float dis = speed * Time.deltaTime;
        transform.Translate(0, dis, 0, Space.Self);

        fireSpe += Time.deltaTime;
        if (fireSpe > fireSpeed)
            fire();
    }

    void fire()
    {
        GameObject blt = Instantiate(bullet);
        blt.transform.position = this.transform.position + new Vector3(-0.3f, 0.5f, 0);
        blt = Instantiate(bullet);
        blt.transform.position = this.transform.position + new Vector3(0.3f, 0.5f, 0);
        fireSpe -= fireSpeed;
    }
}
