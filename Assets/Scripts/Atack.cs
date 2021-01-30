using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atack : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    float speed = 4;

    public void Create(){
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.velocity = new Vector2(speed, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "Enemy"){
            EnemyManager enemy = collision.gameObject.GetComponent<EnemyManager>();
            enemy.DestroyEnemy();
            Destroy(this.gameObject);
        }
    }
}
