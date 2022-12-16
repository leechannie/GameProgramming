using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
 
public class CSVReader : MonoBehaviour
{   
    public Text caltext;
    int ran3;
    public string question;
    public string ans;
     void Start()
    {
        test(); 
    }


     public string getQuestion()
    {
        return question;
    }
    public string getAnswer()
    {
        return ans;
    }



    public List<string>  test()
    {   
        StreamReader sr = new StreamReader(Application.dataPath + "/Resource/" + "Quiz.csv");
        List<string> quiz = new List<string>();
        List<string> section = new List<string>();
        List<string> contents = new List<string>();
        List<string> answer = new List<string>();
        bool endOfFile = false;
        while (!endOfFile)
        {
            string data_String = sr.ReadLine();
            if((object)data_String == null)
            {   
                endOfFile = true;
                break;
            }
            var data_values = data_String.Split(',');
            
            for(int i = 0; i < data_values.Length; i++)
            {   if (i.ToString() == "0"){
                section.Add(data_values[i].ToString());
            }
                if (i.ToString() == "1"){
                contents.Add(data_values[i].ToString());
            }
                if (i.ToString() == "2"){
                answer.Add(data_values[i].ToString());
            }
          //      Debug.Log("v: " + i.ToString() + " " + data_values[i].ToString());
            }

            

        }

        int ran3 = Random.Range(1,80);
        string question = contents[ran3];
        string ans  = answer[ran3];
        Debug.Log(section[ran3] + " : " + contents[ran3]);
        // 아예 csvreader에서 caltext 실행
        caltext.text = section[ran3] + " : " + contents[ran3];
        quiz.Add(caltext.text);
        quiz.Add(ans);
        return quiz;

    }

}


