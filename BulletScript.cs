using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public AudioClip shooting;
    public float speed;
    private Rigidbody2D Rigidbody2D;
    private Vector3 Direction;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Camera.main.GetComponent<AudioSource>().PlayOneShot(shooting);
    }

    private void FixedUpdate() {
        Rigidbody2D.velocity = Direction * speed;    
    }

    public void SetDirection(Vector2 direction){
        Direction = direction;
    }

    public void DestroyBullet(){
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        playerMove player = other.GetComponent<playerMove>();
        GrumScript enemy = other.GetComponent<GrumScript>();
        if (player != null){
            player.Hit();
        } 
        if (enemy != null){
            enemy.Hit();
        }
    }

        
}
