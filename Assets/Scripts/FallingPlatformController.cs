using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatformController : MonoBehaviour
{
    public float fallingTime = 1.5f;

    private TargetJoint2D targetJoint;
    private BoxCollider2D boxCollider;
    // Start is called before the first frame update
    void Start()
    {
        targetJoint = GetComponent<TargetJoint2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Invoke("Falling", fallingTime);
        }

        else
        {
            Destroy(gameObject);
        }
    }
    private void Falling()
    {
        targetJoint.enabled = false;
        boxCollider.isTrigger = false;
    }
}
