using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlayer : MonoBehaviour
{
    Animator anim;
    //PlayerMove playerMove;
    // Start is called before the first frame update
    void Start()
    {
        anim = transform.GetComponent<Animator>();
       // playerMove = GameObject.FindGameObjectWithTag("Player").transform.GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        bool isMoving = Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0;
        //Debug.Log(isMoving);
        anim.SetBool("isMoving", isMoving);

        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("Mouse 0");
        }   
    }

    
}
