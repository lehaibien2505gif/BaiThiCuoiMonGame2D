using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBoll_lenTroi : MonoBehaviour
{
    public int speed = 4;
    Rigidbody2D rigidbody;

    // am thanh
    public AudioSource aus;
    public AudioClip ausclip;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
         transform.Translate(Vector3.up * speed * Time.deltaTime, Space.World);
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("destroy") || col.gameObject.tag.Equals("dat") ){
            Destroy(gameObject);
        } 

         
    }
    
    void OnCollisionStay2D(Collision2D col)
    {}
    void OnCollisionExit2D(Collision2D col)
    {}

}
