using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    float speed;
    Rigidbody2D rigidbody2D;
    //ジャンプ力を設定します。
    float jumpPower = 600;
    [SerializeField] GameManager gameManager;

    Animator animator;
    bool isDead = false;

    [SerializeField]  GameObject atackObject;
    GameObject atack;



    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");

        if(isDead){
            return;
        }

        if( x == 0){
            speed = 0;
        }
        else if(x > 0){
            speed = 3;
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if(x < 0){
            speed = -3;
            transform.localScale = new Vector3(-1, 1, 1);
        }

        rigidbody2D.velocity = new Vector2(speed, rigidbody2D.velocity.y);

        if(Input.GetKeyDown("space")){
            Jump();
        }

        if(Input.GetKeyDown("b")){
            atack = Instantiate(atackObject, this.transform.position, this.transform.rotation);
            Atack at = atack.GetComponent<Atack>();
            at.Create();
        }

    }

    void Jump(){
        rigidbody2D.AddForce(Vector2.up * jumpPower);
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "OUT"){
            // gameManager.GameOver();
            PlayerDeath();
        }

        if(collision.gameObject.tag == "CLEAR"){
            gameManager.GameClear();
        }
        
        if(collision.gameObject.tag == "ITEM"){
            collision.gameObject.GetComponent<ItemManager>().GetItem();
        }

        if(collision.gameObject.tag == "Enemy"){
            
            EnemyManager enemy = collision.gameObject.GetComponent<EnemyManager>();

            if(this.transform.position.y  > enemy.transform.position.y && rigidbody2D.velocity.y <= 0){
                rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, 0);
                Jump();
                enemy.DestroyEnemy();
            }
            else {
                PlayerDeath();
            }
            
        }
    }

    private void PlayerDeath(){
        isDead = true;
        rigidbody2D.velocity = new Vector2(0,0);
        rigidbody2D.AddForce(Vector2.up * jumpPower);
        animator.Play("DeathAnimation");
        BoxCollider2D boxCollider2D = GetComponent<BoxCollider2D>();
        Destroy(boxCollider2D);
        gameManager.GameOver();
    }
}
