using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    public Text txt_Ans;
    public InputField inputTxT_Ans; // 입력 받은 값
    private ConversationManager controlManager;

    GameObject quiz1;
    GameObject quiz2;
    public int quiz1_Ans;
    public string quiz2_Ans;

    public int currentAns;
    void Start(){

    }
    public void quiz1_bring(){
        this.quiz1 = GameObject.Find("ConversationManager");
        this.quiz1.GetComponent<ConversationManager>().Quiz1();
        Invoke("Quiz1()", 2f);
    } 

     public void quiz1_quit(){
        GameObject.Find("ConversationManager").GetComponent<ConversationManager>().Quiz1_Quit();
        inputTxT_Ans.text ="";
        Invoke("Quiz1_Quit()", 2f);
        
    } 

    public void quiz2_bring(){
        this.quiz2 = GameObject.Find("ConversationManager");
        this.quiz2.GetComponent<ConversationManager>().Quiz2();
        Invoke("Quiz2()", 2f);
    } 

     public void quiz2_quit(){
       GameObject.Find("ConversationManager").GetComponent<ConversationManager>().Quiz2_Quit();
        Invoke("Quiz2_Quit()", 2f);
        
    } 

    public void input()
    {    
        GameObject.Find("player").GetComponent<PlayerController>().enabled = true;
        this.quiz1_Ans =this.quiz1.GetComponent<ConversationManager>().Quiz1_return();
        GameObject.Find("ConversationManager").GetComponent<ConversationManager>().CheckAns(int.Parse(inputTxT_Ans.text) == quiz1_Ans);
        //Debug.Log(int.Parse(inputTxT_Ans.text) == quiz1_Ans);
    }
    public void Quiz2input(string ox_ans)
    {    
        this.quiz2_Ans = GameObject.Find("ConversationManager").GetComponent<ConversationManager>().Quiz2_return();
        GameObject.Find("ConversationManager").GetComponent<ConversationManager>().CheckAns(quiz2_Ans==ox_ans);
        //Debug.Log();
    }
}