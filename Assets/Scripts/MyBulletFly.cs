using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyBulletFly : MonoBehaviour
{
    public float speed = 20f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float dis = speed * Time.deltaTime;
        transform.Translate(0, dis, 0, Space.Self);

        Vector3 sp = Camera.main.WorldToScreenPoint(transform.position);
        if (sp.x > Screen.width || sp.y > Screen.height || sp.x < 0 || sp.y < 0)
            Destroy(this.gameObject);
    }
}
