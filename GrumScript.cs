using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrumScript : MonoBehaviour
{
    public GameObject Player;
    public GameObject Bullet;

    private float LastShoot;
    private int health = 3;

    // Update is called once per frame
    void Update()
    {
        if(Player == null) return;

        Vector3 direction = Player.transform.position - transform.position;
        if(direction.x >= 0.0f){
            transform.localScale = new Vector3(1.0f,1.0f,1.0f);
        }else transform.localScale = new Vector3(-1.0f,1.0f,1.0f);

        float distance = Mathf.Abs(Player.transform.position.x - transform.position.x) ;
        if(distance <= 0.5f && Time.time > LastShoot + 0.25f){
            shoot();
            LastShoot = Time.time;
        }
    }

    private void shoot(){
        Vector3 direction;
        if(transform.localScale.x == 1.0f){
            direction = Vector2.right;
        }else direction = Vector2.left;

        GameObject bullet = Instantiate(Bullet,transform.position + direction * 0.1f,Quaternion.identity);
        bullet.GetComponent<BulletScript>().SetDirection(direction);
    }
    public void Hit(){
        health = health - 1;
        if(health == 0){
            Destroy(gameObject);
        }
    } 

}
