using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcController : MonoBehaviour
{
    // Start is called before the first frame update
    float i =1f;
    float beforeI;
    public bool quizCheck = false;
    Vector3 po;

    void OnTriggerEnter2D(Collider2D other) 
    {   
        if(other.tag =="Player"){
        
        beforeI = i;
        i=0;
        }

        else{
            i = -i;
        }
        
    }
    void OnTriggerStay2D(Collider2D other) 
    {   if(other.tag =="Player"){
        i=0;
    }
    }
     
   
    void OnTriggerExit2D(Collider2D other){
        if(other.tag =="Player"){
        i=beforeI;
        }
    }
    void Start()
    {
        po = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        float j = i*0.05f;
        transform.Translate(0,j,0);
        if(this.transform.position.y>po.y +5){
            i = -i;
        }
        if(this.transform.position.y<po.y-5){
            i = -i; 
        }
    }
    
}
