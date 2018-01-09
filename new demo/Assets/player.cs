using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

    private Animator anim;
    private CharacterController controller;

    public float speed = 6.0f;
    public float turnSpeed = 60.0f;
    private Vector3 moveDirection = Vector3.zero;
    public float gravity = 20.0f;


    // Use this for initialization
    void Start () {
        controller = GetComponent<CharacterController>();
        anim = gameObject.GetComponentInChildren<Animator>();
	}

    // Update is called once per frame
    void Update() {
        if (Input.GetKey(KeyCode.W))
        {
            anim.SetInteger("animation", 1);
        } else if (Input.GetMouseButtonDown (0))
        {
            anim.SetInteger("animation", 2);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            anim.SetInteger("animation", 3);
        }
        else if (Input.GetKey(KeyCode.E))
        {
            anim.SetInteger("animation", 4);
        }
        else if (Input.GetKey(KeyCode.X))
        {
            anim.SetInteger("animation", 5);
        }
        else
        {
            anim.SetInteger("animation", 0);
        }

        if (controller.isGrounded)
        {
            moveDirection = transform.forward * Input.GetAxis("Vertical") * speed;
        }

        float turn = Input.GetAxis("Horizontal");
        transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);
        controller.Move(moveDirection * Time.deltaTime);
        moveDirection.y -= gravity * Time.deltaTime;
    }

}
