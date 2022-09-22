using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mario_controll : MonoBehaviour
{
     
    
    public GameObject banDan;
    public static bool facingRight;
      Rigidbody2D rigidbody2D;
      Animator animator;
    public static int diem = 0;
    // public static int mana = 10;
    public Text txt_diem, end_diem;

// end gameOverPanel
    [SerializeField]
    private GameObject gameOver_panel;

    [SerializeField]
    private GameObject hoaQuaTheThan;

    [SerializeField]
    private GameObject Dan;

// am thanh
    public AudioSource aus;
    public AudioClip ausclip;
    public AudioClip ausDie;
    public AudioClip ausChuong;

    void Start()
    {
        facingRight = true;
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
    }

    public int speed = 3;

    void Update()
    {
        float move = Input.GetAxis ("Horizontal");
 
        // animator.SetInteger("status", 1);
        if (Input.GetKeyDown(KeyCode.W)){
            animator.SetInteger("status", 1);       
            rigidbody2D.AddForce(transform.up * 5f, ForceMode2D.Impulse);
            
        }

         if (Input.GetKey(KeyCode.S)){
            animator.SetInteger("status", 0);
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A)){
            animator.SetInteger("status", 0);
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D)){
            animator.SetInteger("status", 0);
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }

        // if(mana == 0){
        //     Destroy(GameObject.Find("fireBoll"));
        // }
        
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            aus.PlayOneShot(ausChuong);
            // mana--;

            if(facingRight){
                Instantiate(banDan, new Vector3(gameObject.transform.position.x + 1.2f, 
                    gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.Euler(0, 0, 0));
            }else if(!facingRight){
                Instantiate(banDan, new Vector3(gameObject.transform.position.x - 1.2f, 
                    gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.Euler(0, 0, 180));
            }    
        }
        
        

        if(Input.GetKeyDown(KeyCode.M)){
                Destroy(GameObject.Find("blockSDiem"));
        }

        if(Input.GetKeyDown(KeyCode.O)){
                _ONDan();
        }

        if(Input.GetKeyDown(KeyCode.P)){
                _OFFDan();
        }

        if(Input.GetKeyDown(KeyCode.B)){
                Destroy(gameObject);
                _ShowHoaQua();

        }
     

        if(move > 0 && !facingRight){
            flip();
        }else if(move < 0 && facingRight){
            flip();
        }

    }

    void flip(){
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }


    void OnCollisionEnter2D(Collision2D col)
     {
        if(col.gameObject.tag.Equals("dongXu")){
             Destroy(col.gameObject);
             aus.PlayOneShot(ausclip);
             diem ++;
             txt_diem.text = "" + diem;
             
        }

        if(col.gameObject.tag.Equals("destroy") || col.gameObject.tag.Equals("boss")){
             Destroy(gameObject);
             aus.PlayOneShot(ausDie);
             end_diem.text = "" + diem;
             _ShowPanel(); 

        }

        if(col.gameObject.tag.Equals("hoaQua")){
             Destroy(col.gameObject);
        }


      }
    
    void OnCollisionStay2D(Collision2D col)
    {}
    void OnCollisionExit2D(Collision2D col)
    {}


    // show end game
    public void _ShowPanel(){
        gameOver_panel.SetActive(true);
    }

    // show hoa qua
    public void _ShowHoaQua(){
        hoaQuaTheThan.SetActive(true);
    }

    // show hoa qua
    public void _ONDan(){
        Dan.SetActive(true);
    }

    // show hoa qua
    public void _OFFDan(){
        Dan.SetActive(false);
    }

}
