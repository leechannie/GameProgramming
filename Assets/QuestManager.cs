using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    GameObject mission_Board;
    GameObject mission_Text;
    public Text questText;
    List<string> drinks = new List<string>();
    List<string> fruits = new List<string>();
    List<string> cookwares = new List<string>();
    List<string> foods = new List<string>();
    List<string> vegetables = new List<string>();
    public List<string> itemList = new List<string>();
    int random_drinks, random_fruits, random_cookwares, random_foods, random_vegetables;
    public bool setTime= false;
    public string questTxt;
    void Start()
    {
        this.mission_Board = GameObject.Find("MissionBoard");
        this.mission_Text = GameObject.Find("MissionText");
        this.mission_Board.SetActive(false);
        this.mission_Text.SetActive(false);

        // 음료 
        drinks.Add("우유");
        drinks.Add("콜라");
        drinks.Add("커피");
        drinks.Add("오렌지주스");
        drinks.Add("알로에주스");

        // 과일
        fruits.Add("사과");
        fruits.Add("딸기");
        fruits.Add("포도");
        fruits.Add("키위");
        fruits.Add("파인애플");

        // 주방용품
        cookwares.Add("수세미");
        cookwares.Add("고무장갑");
        cookwares.Add("행주");
        cookwares.Add("키친타월");
        cookwares.Add("쿠킹호일");

        // 음식
        foods.Add("빵");
        foods.Add("라면");
        foods.Add("생선");
        foods.Add("닭고기");
        foods.Add("돼지고기");

        // 채소
        vegetables.Add("양배추");
        vegetables.Add("양파");
        vegetables.Add("상추");
        vegetables.Add("깻잎");
        vegetables.Add("오이");

        

        
    }

    // Update is called once per frame
    void Update()
    {
        if(setTime == false){
            // 랜덤
        itemList = new List<string>();
        random_drinks = Random.Range(0, 5);
        random_fruits = Random.Range(0, 5);
        random_cookwares = Random.Range(0, 5);
        random_foods = Random.Range(0, 5);
        random_vegetables = Random.Range(0, 5);

        // 심부름 목록
        itemList.Add(drinks[random_drinks]);
        itemList.Add(fruits[random_fruits]);
        itemList.Add(cookwares[random_cookwares]);
        itemList.Add(foods[random_foods]);
        itemList.Add(vegetables[random_vegetables]);
        questTxt = ListToText(itemList);
        }
    }

    public string ListToText(List<string> list)
    {   
        
        string result = "\n심부름 목록 \n\n";
        foreach (var listMember in list)
        {
            result += listMember + "\n\n";
        }
        return result;
    }

    public void mission()
    {
        this.mission_Board.SetActive(true);
        this.mission_Text.SetActive(true);
        questText.text = questTxt;
    }

    public void missionQuit()
    {
        this.mission_Board.SetActive(false);
        this.mission_Text.SetActive(false);
    }

}