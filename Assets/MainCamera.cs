using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {   
        this.player = GameObject.Find("player");
    }

    // Update is called once per frame
    public void LateUpdate()
    {
        Vector3 playerPos = this.player.transform.position;
        if(playerPos.x >10){
            playerPos.x =10;
        }
        if(playerPos.x <-10){
            playerPos.x =-10;
        }
         if(playerPos.y <-10){
            playerPos.y =-10;
        }
        if(playerPos.y >10){
            playerPos.y =10;
        }
        transform.position = new Vector3(
            playerPos.x, playerPos.y, transform.position.z);
    }

   
}