using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class PlayerMoveRigidbody : MonoBehaviour
{

    #region Inspector variables
    [SerializeField] float speed = 10f;
    [SerializeField] private float jumpFroce = 3f;
    [SerializeField] private float dashMultiplier = 2f;
    [SerializeField] float slideSpeed = 2f;
    [SerializeField] float slideHeight = 0.5f;
    [SerializeField] float distToGround = 0.5f;
    [SerializeField] float crouchSpeed = 5f;
    #endregion

    #region Input
    float horizontal;
    float vertical;
    bool space;
    bool leftControlDown;
    bool leftControlUp;
    bool leftShift;
    #endregion

    #region Script variables
    Vector3 moveAmount;
    Vector3 smoothMoveVelocity;      
    float defaultHeight;
    float defaultSpeed;
    #endregion

    #region References
    Rigidbody rig;
    CapsuleCollider collider;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        rig = gameObject.GetComponent<Rigidbody>();
        collider = gameObject.GetComponent<CapsuleCollider>();
        defaultHeight = collider.height;
        defaultSpeed = speed;

    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        Jump();
        Dash();
        Slide();
        Crouch();
    }

    private void FixedUpdate()
    {
        Movement(horizontal, vertical);
    }
    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
    }
    void Movement(float x, float z)
    {
        Vector3 move = new Vector3(x, 0, z).normalized;
        Vector3 targetMoveAmount = move * speed;
        moveAmount = Vector3.SmoothDamp(moveAmount, targetMoveAmount, ref smoothMoveVelocity, .15f);
        rig.MovePosition(rig.position + transform.TransformDirection(moveAmount) * Time.deltaTime);
    }
    void Jump()
    {
        if (IsGrounded() && space)
        {
            Debug.Log("Jump");
            rig.AddForce(transform.up * jumpFroce);
        }
        
    }
    void Dash()
    {
        if (leftShift)
        {
            Debug.Log("Dash");
            rig.MovePosition(rig.position + transform.TransformDirection(moveAmount) * Time.fixedDeltaTime * dashMultiplier);
        }
       
    }
    void Slide()
    {
        if (leftControlDown && vertical != 0)
        {
            rig.AddForce(transform.forward * slideSpeed, ForceMode.VelocityChange);
            Crouch();
        }
        
        
    }
    void Crouch()
    {
        if (leftControlDown)
        {
            speed = crouchSpeed;
            collider.height = slideHeight;
            Debug.Log("crouch");
        }
        else if (leftControlUp)
        {
            speed = defaultSpeed;
            collider.height = defaultHeight;
        }
    }
    void GetInput()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        space = Input.GetKeyDown(KeyCode.Space);
        leftControlDown = Input.GetKeyDown(KeyCode.LeftControl);
        leftControlUp = Input.GetKeyUp(KeyCode.LeftControl);
        leftShift= Input.GetKeyDown(KeyCode.LeftShift); 
    }

    

}
