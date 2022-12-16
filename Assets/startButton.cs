using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class startButton : MonoBehaviour
{

    GameObject player;
   // GameObject Ludo;
    //GameObject Luna;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("player").GetComponent<PlayerController>().enabled = false;
        GameObject.Find("LudoPrefab").GetComponent<NpcController2>().enabled = false;
        GameObject.Find("LudoPrefab (1)").GetComponent<NpcController>().enabled = false;
        GameObject.Find("LudoPrefab (2)").GetComponent<NpcController2>().enabled = false;
        GameObject.Find("LudoPrefab (3)").GetComponent<NpcController>().enabled = false;
        GameObject.Find("LudoPrefab (4)").GetComponent<NpcController2>().enabled = false;
        GameObject.Find("LudoPrefab (5)").GetComponent<NpcController>().enabled = false;
        GameObject.Find("LudoPrefab (6)").GetComponent<NpcController2>().enabled = false;
        //.GetComponent<PlayerController>();
       // GameObject Ludo = gameObject.Find("Ludo");  
        //GameObject Luna = gameObject.Find("Luna");
        //player.enabled = false;
        //Ludo.enabled = false;
        //Luna.enabled = false;
    }

    // Update is called once per frame
    public void ClickBtn(){
       // GameObject.Find("player").GetComponent<PlayerController>().GetComponent<audioMove>.Play();
        GameObject.Find("player").GetComponent<PlayerController>().enabled = true;
        GameObject.Find("LudoPrefab").GetComponent<NpcController2>().enabled = true;
        GameObject.Find("LudoPrefab (1)").GetComponent<NpcController>().enabled = true;
        GameObject.Find("LudoPrefab (2)").GetComponent<NpcController2>().enabled = true;
        GameObject.Find("LudoPrefab (3)").GetComponent<NpcController>().enabled = true;
        GameObject.Find("LudoPrefab (4)").GetComponent<NpcController2>().enabled = true;
        GameObject.Find("LudoPrefab (5)").GetComponent<NpcController>().enabled = true;
        GameObject.Find("LudoPrefab (6)").GetComponent<NpcController2>().enabled = true;
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySound("MOVE");
    }
}
