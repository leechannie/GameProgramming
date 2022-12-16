using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class OXController : MonoBehaviour
{

    public void ClickBtn()
    {
        GameObject clickObject = EventSystem.current.currentSelectedGameObject;
        GameObject.Find("player").GetComponent<PlayerController>().enabled = true;
      //  Debug.Log (clickObject.name);
        GameObject.Find("Canvas").GetComponent<Test>().Quiz2input(clickObject.name);

       
    }
}
