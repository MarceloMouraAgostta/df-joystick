using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player4 : MonoBehaviour
{
    [SerializeField] private Joystick joystick;//novo


    public CharacterController controller;
    private Animator anim;

    public float speed;
    public float speed2;//nv

    public float gravity;
    public float rotSpeed;

    private float rot;
    private Vector3 moveDirection;
    private float verticalInput;//nv

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        float xMovement = joystick.Horizontal;//nv
        float zMovement = joystick.Vertical;//nv
        transform.position += new Vector3(xMovement, 0f, zMovement) * speed2 * Time.deltaTime;//nv
        rot += xMovement * rotSpeed * Time.deltaTime;//nv
        if (xMovement != 0)//nv
        {
            anim.SetBool("IsMoving", true);
        }
        else
        {
            anim.SetBool("IsMoving", false);
        }

    }

    void Move()
    {
        if (controller.isGrounded)
        {
            if (Input.GetKey(KeyCode.W))
            {
                moveDirection = Vector3.forward * speed;
                anim.SetBool("IsMoving", true);
            }
            if (Input.GetKeyUp(KeyCode.W))
            {
                moveDirection = Vector3.zero;
                anim.SetBool("IsMoving", false);
            }

        }

        rot += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, rot, 0);

        moveDirection.y -= gravity * Time.deltaTime;
        moveDirection = transform.TransformDirection(moveDirection);

        controller.Move(moveDirection * Time.deltaTime);
    }
}
