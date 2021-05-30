using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    public GameObject Bullet;
    public float JumpForce;
    public float speed;
    public int DamageBonus;

    private Rigidbody2D Rigidbody2D; 
    private float Horizontal;
    private bool suelo;
    private Animator Animator;
    private float LastShoot;
    public int health = 10;
    private float TimeBonus;
    private float bonusInitTime;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");

        if(Horizontal < 0.0f){
            transform.localScale = new Vector3(-1.0f, 1.0f , 1.0f);
        }
        else if (Horizontal > 0.0f){
            transform.localScale = new Vector3(1.0f, 1.0f , 1.0f);
        }

        Animator.SetBool("Running", Horizontal != 0.0f);
        Animator.SetBool("Ground", suelo == false);
        
        Debug.DrawRay(transform.position, Vector3.down * 0.1f, Color.red);
        if(Physics2D.Raycast(transform.position, Vector3.down , 0.1f))
        {
            suelo = true;
        }
        else{
            suelo = false;
        }

        if(Input.GetKey(KeyCode.Space) && Time.time >  LastShoot + 0.25f){
            shoot();
            LastShoot = Time.time;
        }

        if(Input.GetKeyUp(KeyCode.W) && suelo == true)
        {
            Jump();
        }

        if((Time.time - bonusInitTime)>TimeBonus){
            DamageBonus = 0;
        }
    }

    private void Jump()
    {
        Rigidbody2D.AddForce(Vector2.up* JumpForce);
    }

    private void shoot(){
        Vector3 direction;
        if(transform.localScale.x == 1.0f){
            direction = Vector2.right;
        }else direction = Vector2.left;
        GetComponent<moneyScript>().viewCash();
        GameObject Bullets = Instantiate(Bullet,transform.position + direction * 0.1f ,Quaternion.identity);
        Bullets.GetComponent<BulletScript>().setBonus(DamageBonus);
        Bullets.GetComponent<BulletScript>().SetDirection(direction);
    }

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(Horizontal,Rigidbody2D.velocity.y);
    }

    public void Hit(){
        health = health - 1;
        if(health <= 0){
            Destroy(gameObject);
        }
    }

    public void damageBonus(int Bonus,float time,int healhing){
        DamageBonus = Bonus;
        TimeBonus = time;
        bonusInitTime = Time.time;
        for(int i=0;i < healhing;i++){
            if(health == 10){
                break;
            }
            else{
               health += 1; 
            }          
        }
    }

}
