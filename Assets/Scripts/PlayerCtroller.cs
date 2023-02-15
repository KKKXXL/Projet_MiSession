using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCtroller : MonoBehaviour
{
    //Variable pour le InputSystem
    private bool jump = false;
    private float h = 0;
    //Variable pour l'animator
    private Animator anim;
    private Locomotion character;


    void Start()
    {
        anim = GetComponent<Animator>();
        character = GetComponent<Locomotion>();
    }

    // Start is called before the first frame update

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 move = context.ReadValue<Vector2>();
        h = move.x;
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        jump = context.performed;
    }
    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("h", Mathf.Abs(h));

    }

    private void FixedUpdate()
    {
        character.Move(h,jump);
        jump = false;
    }

}
