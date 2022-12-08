using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PMove : MonoBehaviour
{
    //public float rotationSpeed;

    private Animator animator;
    [SerializeField] private float speed;
    [SerializeField] private Joystick joystick;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        

        float xMovement = joystick.Horizontal;
        float zMovement = joystick.Vertical;

        

        transform.position += new Vector3(xMovement, 0f, zMovement) * speed * Time.deltaTime;

        //float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        /*Vector3 movementDirection = new Vector3(xMovement, 0, verticalInput);
        //float magnitude = Mathf.Clamp01(zMovement) * speed;

        if (movementDirection != Vector3.zero)
        {
            animator.SetBool("IsMoving", true);
            //Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            //transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);

        }
        else
        {
            animator.SetBool("IsMoving", false);
        }*/

    }
}
