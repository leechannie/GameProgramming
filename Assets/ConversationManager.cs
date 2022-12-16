using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ConversationManager : MonoBehaviour
{
    CSVReader csvreader;
    public Text caltext;
    int calcount;
    int ran1;
    int ran2;
    string quiz_text;
    string quiz_ans;
    public int quiz1_Ans;
    GameObject image;
    GameObject text;
    GameObject O;
    GameObject X;
    string que;
    GameObject button;
    GameObject inputField;
    public int num;
    List<string>  quizlist;
    string product;
    List<string> itemList;
    List<string> itemTemp = new List<string>();
    // public string[] que;
    void Start()
    {
        this.image = GameObject.Find("quiz");
        this.text = GameObject.Find("Text");
        this.O = GameObject.Find("O");
        this.X = GameObject.Find("X");
        this.button = GameObject.Find("Button");
        this.inputField = GameObject.Find("InputField");
        this.image.SetActive(false);
        this.text.SetActive(false);
        this.O.SetActive(false);
        this.X.SetActive(false);
        this.inputField.SetActive(false);
        this.button.SetActive(false);

        
    }
    

    public void Quiz1()
    {
        // int questioncount=Random.Range(1,2);
        int calcount = Random.Range(1,5);
        int ran1 = Random.Range(1,11);
        int ran2 = Random.Range(1,11);
        this.image.SetActive(true);
        this.text.SetActive(true);
        this.button.SetActive(true);
        this.inputField.SetActive(true);
        // if (questioncount==1)

        if (calcount==1)
        {
            this.caltext.text = ran1 + " + " + ran2;
            this.quiz1_Ans = ran1 + ran2;
        }
        if (calcount==2)
        {
            this.caltext.text = ran1 + " - " + ran2;
            this.quiz1_Ans = ran1 - ran2;
        }
        if (calcount==3)
        {
            this.caltext.text = ran1 + " x " + ran2;
            this.quiz1_Ans = ran1 * ran2;
        }
        if (calcount==4)
        {
            this.caltext.text = ran1 + " ÷ " + ran2;
            this.quiz1_Ans = ran1 / ran2;
        }   
    }
    public int Quiz1_return(){
        return this.quiz1_Ans;
    }
    public string Quiz2_return(){
        return this.quizlist[1];
        
    }
    public void Quiz2()
    {
        this.image.SetActive(true);
        this.text.SetActive(true);
        CSVReader reader = GameObject.Find("GameObject").GetComponent<CSVReader>();
        quizlist = reader.test();
        this.O.SetActive(true);
        this.X.SetActive(true);


    }
    public void Quiz1_Quit()
    {
        this.image.SetActive(false);
        this.text.SetActive(false);
       
}   
public void Quiz2_Quit()
    {
        this.image.SetActive(false);
        this.text.SetActive(false);

    }
public void set(bool setAns){
    if(setAns){
        product = GameObject.Find("player").GetComponent<PlayerController>().product;
        itemList = GameObject.Find("QuestManager").GetComponent<QuestManager>().itemList;
        for(int i =0; i<itemList.Count;i++){
        itemTemp.Add(itemList[i]);}; }
}

public void CheckAns(bool ans)
    {   
        product = GameObject.Find("player").GetComponent<PlayerController>().product;
 //       itemList = GameObject.Find("QuestManager").GetComponent<QuestManager>().itemList;
        if(ans==true){
            this.caltext.text = "정답! 물품 " + product+"을(를) 얻었어요!";
            for(int i =0; i<itemTemp.Count;i++){
                Debug.Log(itemTemp[i]);
                if(itemTemp[i] == product){
                GameObject.Find("player").GetComponent<PlayerController>().right +=1;
                switch (i)
                {
                    case 0:
                        Destroy(GameObject.Find("drink"));
                        num += 1;
                        break;
                    case 1:
                        Destroy(GameObject.Find("fruit"));
                        Debug.Log("1");
                        num += 1;
                        break;
                    case 2:
                        Destroy(GameObject.Find("cookware"));
                        num += 1;
                        break;
                    case 3:
                        Destroy(GameObject.Find("food"));
                        num += 1;
                        break;
                    case 4:
                        Destroy(GameObject.Find("vegetable"));
                        num += 1;
                        break;
                }
                itemList.Remove(product);
                GameObject.Find("QuestManager").GetComponent<QuestManager>().questTxt = GameObject.Find("QuestManager").GetComponent<QuestManager>().ListToText(itemList);
                
                if(num == 5)
                    {
                        SceneManager.LoadScene("EndingScene");
                    }
                break;
            }
            }
            
        }
        else{
            this.caltext.text = "오답! 물품 " + product+ "을(를) 못 얻었어요!";
        }
        this.button.SetActive(false);
        this.inputField.SetActive(false);
        this.O.SetActive(false);
        this.X.SetActive(false);
        GameObject.Find("player").GetComponent<PlayerController>().qusetions -=1;
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySound("MOVE");
    }   
}



