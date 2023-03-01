using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyFighter : MonoBehaviour
{
    public GameObject bullet;
    float fireSpe = 0f;
    public float fireSpeed = 0.3f;

    public float speed = 7f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 sp = Camera.main.WorldToScreenPoint(transform.position);
        float step = speed * Time.deltaTime;
        if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) && sp.x > 0)
        {
            transform.Translate(-step, 0, 0, Space.Self);
        }
        if ((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) && sp.x < Screen.width)
        {
            transform.Translate(step, 0, 0, Space.Self);
        }
        if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) && sp.y < Screen.height)
        {
            transform.Translate(0, step, 0, Space.Self);
        }
        if ((Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) && sp.y > 0)
        {
            transform.Translate(0, -step, 0, Space.Self);
        }

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
