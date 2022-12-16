using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
   
    Animator animator;
    Rigidbody2D rigid2D;
    Vector3 playerPos;
    Vector3 move;
    bool quizbool = false;
    bool setAns = true;
    GameObject sound;
    GameObject manager;
    public string product;
    public int qusetions = 25;
    public int right = 0;


    float h;
    float v;
    
    void Awake(){
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySound("END");
    }

    void Update(){
        h =Input.GetAxisRaw("Horizontal")*7;
        v =Input.GetAxisRaw("Vertical")*7;
        
    }

    void FixedUpdate(){

        
        if(Input.GetKey(KeyCode.UpArrow)){
                this.animator.SetTrigger("Up");
                rigid2D.velocity = new Vector2(0,v);
                this.animator.speed = 0.5f;
            
        }
       else if(Input.GetKey(KeyCode.DownArrow)){
            
                this.animator.SetTrigger("Down");
                rigid2D.velocity = new Vector2(0,v);
                this.animator.speed = 0.5f; 

            
        }
        else if(Input.GetKey(KeyCode.RightArrow)){
            
                this.animator.SetTrigger("Right");
                rigid2D.velocity = new Vector2(h,0);
                this.animator.speed = 0.5f;
            
        }
        else if(Input.GetKey(KeyCode.LeftArrow)){
            
                this.animator.SetTrigger("Left");
                rigid2D.velocity = new Vector2(h,0);
                this.animator.speed = 0.5f;
            
        }
        else{
            rigid2D.velocity = new Vector2(0,0);
            this.animator.speed = 0.0f;
        }
        if(Input.GetKeyUp(KeyCode.Space)){
            if(quizbool){
                GameObject.Find("Canvas").GetComponent<Test>().quiz1_bring();
                this.enabled = false;
                rigid2D.velocity = new Vector2(0,0);
                this.animator.speed = 0.0f;
                GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySound("SOLVE");
            }
        }
        
    }




   void OnTriggerEnter2D(Collider2D other) 
    {   
        if (other.gameObject.tag == "알로에주스" || other.gameObject.tag == "사과" || other.gameObject.tag == "양배추")
        {   
            if(other.gameObject.GetComponent<NpcController>().quizCheck == false){
            product = other.gameObject.tag ;
            GameObject.Find("ConversationManager").GetComponent<ConversationManager>().Quiz2();
            this.enabled = false;
            rigid2D.velocity = new Vector2(0,0);
            this.animator.speed = 0.0f;
            GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySound("SOLVE");
            }
        }
        if (other.gameObject.tag == "수세미" || other.gameObject.tag == "빵" || other.gameObject.tag == "양파" || other.gameObject.tag == "상추")
        {   
            if(other.gameObject.GetComponent<NpcController2>().quizCheck == false){
            product = other.gameObject.tag ;
            GameObject.Find("ConversationManager").GetComponent<ConversationManager>().Quiz2();
            this.enabled = false;
            rigid2D.velocity = new Vector2(0,0);
            this.animator.speed = 0.0f;
            GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySound("SOLVE");
            }
        }

    }
     void OnTriggerStay2D(Collider2D other) 
    {   
     
        if (other.gameObject.tag == "mother" && Input.GetKeyUp(KeyCode.Space)){
            SceneManager.LoadScene("EndingScene");
        }
        

    }
     
   
    void OnTriggerExit2D(Collider2D other){
       
        if (other.gameObject.tag == "알로에주스" || other.gameObject.tag == "사과" || other.gameObject.tag == "양배추")
        {   if(other.gameObject.GetComponent<NpcController>().quizCheck == false){
            GameObject.Find("ConversationManager").GetComponent<ConversationManager>().Quiz2_Quit();
            other.gameObject.GetComponent<NpcController>().quizCheck= true;}
        }
        if (other.gameObject.tag == "수세미" || other.gameObject.tag == "빵" || other.gameObject.tag == "양파" || other.gameObject.tag == "상추")
        {   if(other.gameObject.GetComponent<NpcController2>().quizCheck == false){
            GameObject.Find("ConversationManager").GetComponent<ConversationManager>().Quiz2_Quit();
            other.gameObject.GetComponent<NpcController2>().quizCheck = true;}
        }
        
        
    }
     
       void OnCollisionEnter2D(Collision2D other)
    {
       if(other.gameObject.tag != "obstacle" && other.gameObject.tag != "house" && other.gameObject.tag != "알로에주스" && other.gameObject.tag != "사과" && other.gameObject.tag != "양배추" && other.gameObject.tag != "수세미" && other.gameObject.tag != "빵" && other.gameObject.tag != "양파" && other.gameObject.tag != "상추" && other.gameObject.tag != "mother"){
         product = other.gameObject.tag ;
         quizbool = true;}
         if (other.gameObject.tag == "house")
        {   GameObject.Find("ConversationManager").GetComponent<ConversationManager>().set(setAns);
            GameObject.Find("QuestManager").GetComponent<QuestManager>().setTime = true;
            GameObject.Find("QuestManager").GetComponent<QuestManager>().mission();
            GameObject.Find("LudoPrefab").GetComponent<NpcController2>().enabled = false;
            GameObject.Find("LudoPrefab (1)").GetComponent<NpcController>().enabled = false;
            GameObject.Find("LudoPrefab (2)").GetComponent<NpcController2>().enabled = false;
            GameObject.Find("LudoPrefab (3)").GetComponent<NpcController>().enabled = false;
            GameObject.Find("LudoPrefab (4)").GetComponent<NpcController2>().enabled = false;
            GameObject.Find("LudoPrefab (5)").GetComponent<NpcController>().enabled = false;
            GameObject.Find("LudoPrefab (6)").GetComponent<NpcController2>().enabled = false;
            setAns = false;
        }

        
    }
   void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.tag != "obstacle" && other.gameObject.tag != "house" && other.gameObject.tag != "알로에주스" && other.gameObject.tag != "사과" && other.gameObject.tag != "양배추" && other.gameObject.tag != "수세미" && other.gameObject.tag != "빵" && other.gameObject.tag != "양파" && other.gameObject.tag != "상추" && other.gameObject.tag != "mother"){
        quizbool = false;
        GameObject.Find("Canvas").GetComponent<Test>().quiz1_quit();
        
    }
    if (other.gameObject.tag == "house")
        {
            GameObject.Find("QuestManager").GetComponent<QuestManager>().missionQuit();
            GameObject.Find("LudoPrefab").GetComponent<NpcController2>().enabled = true;
            GameObject.Find("LudoPrefab (1)").GetComponent<NpcController>().enabled = true;
            GameObject.Find("LudoPrefab (2)").GetComponent<NpcController2>().enabled = true;
            GameObject.Find("LudoPrefab (3)").GetComponent<NpcController>().enabled = true;
            GameObject.Find("LudoPrefab (4)").GetComponent<NpcController2>().enabled = true;
            GameObject.Find("LudoPrefab (5)").GetComponent<NpcController>().enabled = true;
            GameObject.Find("LudoPrefab (6)").GetComponent<NpcController2>().enabled = true;
        }

   

    

}}