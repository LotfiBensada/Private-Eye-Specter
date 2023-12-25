using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouvementJoueur : MonoBehaviour
{
    public float walkingSpeed;
    public float runningSpeed;
    float moveSpeed; // Speed at which the character will move
    bool isSprinting = false;
    float hInput, vInput; // Horizontal and vertical input

    [HideInInspector] public Vector3 direction; // Direction vector

    CharacterController controller; //controller of the character

    [SerializeField] float groundYOffset;
    [SerializeField] LayerMask groundMask;
    [SerializeField] float gravity = -9.81f;

    Vector3 spherePos;
    Vector3 velocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        moveSpeed = walkingSpeed;
    }

    void Update()
    {
        IsSprinting();
        GetDirectionAndMove();
        Gravity();
    }


    //Method that will get the direction input and make the character move depending on them
    void GetDirectionAndMove()
    {
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");
    
        direction = transform.forward * vInput + transform.right * hInput; //makes it so that the character will always be facing forward
        controller.Move(direction * moveSpeed * Time.deltaTime);
    }
    
    void IsSprinting()
    {
        if(Input.GetKey(KeyCode.LeftShift)) 
        {
            if (!isSprinting)
            {
                moveSpeed = runningSpeed;
                isSprinting = true;
            }
            
        }
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed = walkingSpeed;
            isSprinting = false;
        }
    }
    bool isGrounded()
    {
        spherePos = new Vector3(transform.position.x, transform.position.y - groundYOffset, transform.position.z);
        if (Physics.CheckSphere(spherePos, controller.radius - 0.05f, groundMask)) return true;
        return false;
    }

    void Gravity()
    {
        if (!isGrounded())
        {
            velocity.y += gravity * Time.deltaTime;
        }
        else if (velocity.y < 0) velocity.y = -2;

        controller.Move(velocity * Time.deltaTime);
    }



}
