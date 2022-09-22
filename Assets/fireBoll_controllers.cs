using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fireBoll_controllers : MonoBehaviour
{

    public Text txt_diem;
    public AudioSource aus;
    public AudioClip ausclip;

    public int speed = 4;
    public GameObject vuNo;

    void Start()
    {
       
    }


    void Update()
    {
        
        if(transform.localRotation.z >0){
             transform.Translate(new Vector3(-1, 0, 0)* speed * Time.deltaTime, Space.World);
        }else{
             transform.Translate(new Vector3(1, 0, 0) * speed * Time.deltaTime, Space.World);
        }

    }

    void OnCollisionEnter2D(Collision2D col)
        {
        
        if (col.gameObject.tag.Equals("dat")){
            Destroy(gameObject);
        } 

        if (col.gameObject.tag == "boss")
        {
            aus.PlayOneShot(ausclip);
            Destroy(col.gameObject);
            Destroy(gameObject);
            Instantiate(vuNo, col.gameObject.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            Mario_controll.diem += 2;
            txt_diem.text = "" + Mario_controll.diem;
        }

        if(col.gameObject.tag == "destroy"){
            Destroy(gameObject);
        }
        if(col.gameObject.tag == "dat"){
            Destroy(gameObject);
        }
    
    }
    
    void OnCollisionStay2D(Collision2D col)
    {

    }
    void OnCollisionExit2D(Collision2D col)
    {

    }


}
