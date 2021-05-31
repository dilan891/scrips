using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slimeEnemy : MonoBehaviour
{

    public int jumpForce;

    private Rigidbody2D Rigidbody2D;
    private bool suelo;
    private bool jump;
    private float lastJump;
    private Animator Animator;
    // Update is called once per frame

    void Start() {
         Animator = GetComponent<Animator>();    
         Rigidbody2D = GetComponent<Rigidbody2D>(); 
    }

    void Update()
    {

        Animator.SetBool("Ground",suelo == false);

        if(lastJump == 0 || Time.time > (lastJump + 3.0f)){
            jump = true;
            Animator.SetBool("Jump",jump);
            lastJump = Time.time;
            Rigidbody2D.AddForce(Vector2.up* jumpForce);
            jump = false;
        }

        if(Physics2D.Raycast(transform.position, Vector3.down , 0.1f))
        {
            suelo = true;
        }
        else{
            suelo = false;
        }
    }

}
