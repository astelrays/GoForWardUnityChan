using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanController : MonoBehaviour
{
    Animator animator;
    private float groundLevel =-3.0f;
    private Rigidbody2D rigid2D;
   

    private float dump=0.8f;

    float jumpCelocity=20;
    private float deadLine=-9;
    bool isVolume=false;
    // Start is called before the first frame update
    void Start()
    {
        this.animator=GetComponent<Animator>();

        this.rigid2D=GetComponent<Rigidbody2D>();
       
    }

    // Update is called once per frame
    void Update()
    {
        this.animator.SetFloat("Horizontal",1);
        bool isGround=(transform.position.y>this.groundLevel)?false:true;
        GetComponent<AudioSource>().volume=(isGround) ? 1:0;
        this.animator.SetBool("isGround",isGround);
       
        
        if(Input.GetMouseButtonDown(0)&&isGround)
        {
          this.rigid2D.velocity=new Vector2(0,this.jumpCelocity);
        }
        if(Input.GetMouseButton(0)==false)
        {
           if(this.rigid2D.velocity.y>0)
           {
              this.rigid2D.velocity*=this.dump;
           }
        }
        if(transform.position.x<this.deadLine)
        {
          GameObject.Find("Canvas").GetComponent<UIController>().GameOver();
          Destroy(gameObject);
        }
        if(isGround==true&&isVolume==true)
        {
          GetComponent<AudioSource>().volume=(isGround)?0:0;
        }
        
      
    }
    
}    
    
