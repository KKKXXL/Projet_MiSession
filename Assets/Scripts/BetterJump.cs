using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterJump : MonoBehaviour
{
    private Rigidbody2D rigid;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (rigid.velocity.y < 0)
        {
            rigid.gravityScale = fallMultiplier;
        }
        else if (rigid.velocity.y > 0 && !Input.GetButtonDown("Jump"))
        {
            rigid.gravityScale = lowJumpMultiplier;
        }
        else 
        {
            rigid.gravityScale = 1f;
        }
    }
}
