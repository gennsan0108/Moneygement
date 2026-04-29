using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class MemberListManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject popupPanel;

    public GameObject MemberLabel;
    public Transform content;
    public Sprite defaultIconSprite;
    //public ManagementRoom mr = HomeScreenManager.currentRoom;



    void Start()
    {

        ManagementRoom mr = HomeScreenManager.currentRoom;

        List<PersonManagement> PMlist = mr.MembersListBack();
        Debug.Log(mr.MembersListBack().Count);//後で消す

        foreach (PersonManagement pm in PMlist)
        {

            GameObject label = Instantiate(MemberLabel, content);

            //タグの名前
            label.GetComponentInChildren<TextMeshProUGUI>().text = pm.playerName;

            GameObject icon = label.transform.Find("HorizontalRow/Icon").gameObject;
            icon.GetComponent<Image>().sprite = defaultIconSprite;



        }


    }

    // Update is called once per frame
    

   
  
}
