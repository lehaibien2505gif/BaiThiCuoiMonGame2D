using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class thanhNo_controllers : MonoBehaviour
{
    public AudioSource aus;
    public AudioClip ausclip;
    public GameObject vuNo;

    // partycle system
    [SerializeField]
    private GameObject Partycle;

    void Start()
    {

    }


    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "dat" )
        {
            aus.PlayOneShot(ausclip);
            Destroy(col.gameObject);
            Destroy(gameObject);
            Instantiate(vuNo, col.gameObject.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            _ShowPartycle(); 
        }
    }
    
    void OnCollisionStay2D(Collision2D col)
    {}
    void OnCollisionExit2D(Collision2D col)
    {}

    // show partycle sytem
    public void _ShowPartycle(){
        Partycle.SetActive(true);
    }

}
