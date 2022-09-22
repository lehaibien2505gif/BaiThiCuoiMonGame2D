using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_controllers : MonoBehaviour
{
    
    public float speed = 2f;
    bool switc = true;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        if(switc){
            moveBossRight();
        }
        if(!switc){
            moveBossLeft();
        }
        if(transform.position.x >= 26f){
            switc = false;
            spriteRenderer.flipX = false;
        }
        if(transform.position.x <= 18f){
            switc = true;
            spriteRenderer.flipX = true;
        }

    }

    
    void moveBossRight(){
        transform.Translate(speed * Time.deltaTime,0,0);
    }

    void moveBossLeft(){
        transform.Translate(-speed * Time.deltaTime,0,0);
    }



}
