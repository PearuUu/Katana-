using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMove : MonoBehaviour
{
    CharacterController characterController;
    [SerializeField] float speed = 20f;
    [SerializeField] private float jumpFroce = 3f;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float dashMultiplier = 2f;
    Vector3 velocity;
    [HideInInspector ]public bool isMoving;
    

    // Start is called before the first frame update
    void Start()
    {
        characterController = gameObject.GetComponent<CharacterController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        Movement();
        Gravity();
        Jump();
    }

    void Movement()
    {
        Vector3 move = transform.right * GetInput().x + transform.forward * GetInput().z;
        characterController.Move(move * speed * Time.deltaTime);
        Dash(move);   
    }

    

    void Jump()
    {
        if(characterController.isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            velocity.y = Mathf.Sqrt(jumpFroce * -2f * gravity);
            characterController.Move(velocity * Time.deltaTime);
        }
    }

    void Dash(Vector3 move)
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            characterController.Move(move * speed * Time.deltaTime * dashMultiplier);
        }
    }
 
    void Gravity()
    {
        if(characterController.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }
    (float x,float z) GetInput()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        

        return (horizontal,vertical);
    }

    

}
