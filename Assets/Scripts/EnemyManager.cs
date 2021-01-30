using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] LayerMask blockLayer;
    Rigidbody2D rigidbody2D;
    float speed = 0;
    string direction = "left";

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!IsGround()){
            ChangeDirection();
        }

        if(direction =="left"){
            speed = -1;
            transform.localScale = new Vector3(1, 1, 1);
        }
        else{
            speed = 1;
            transform.localScale = new Vector3(-1, 1, 1);
        }

        rigidbody2D.velocity = new Vector2(speed, rigidbody2D.velocity.y);
    }

    void ChangeDirection(){
        if(direction == "left"){
            direction = "right";
        }
        else{
            direction = "left";
        }
    }

    bool IsGround(){
        Vector3 startVec = transform.position - transform.right * 0.7f * transform.localScale.x;
        Vector3 endVec = startVec - transform.up * 0.8f;
        return Physics2D.Linecast(startVec, endVec, blockLayer);
    }

    public void DestroyEnemy()
    {
        Destroy(this.gameObject);
    }
}
