using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sinhDiem_controllers : MonoBehaviour
{
    public AudioSource aus;
    public AudioClip ausclip;
    public GameObject vuNo;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "dat" || col.gameObject.tag == "Mario" )
        {
            aus.PlayOneShot(ausclip);
            Destroy(col.gameObject);
            Destroy(gameObject);
            Instantiate(vuNo, col.gameObject.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));

        }
         

    }
    
    void OnCollisionStay2D(Collision2D col)
    {}
    void OnCollisionExit2D(Collision2D col)
    {}

}
