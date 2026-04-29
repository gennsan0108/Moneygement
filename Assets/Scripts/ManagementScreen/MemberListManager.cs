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
    public TextMeshProUGUI titleText;
    //public ManagementRoom mr = HomeScreenManager.currentRoom;



    void Start()
    {

        ManagementRoom mr = HomeScreenManager.currentRoom;

        List<PersonManagement> PMlist = mr.MembersListBack();
        

        foreach (PersonManagement pm in PMlist)
        {

            GameObject label = Instantiate(MemberLabel, content);

            //タグの名前
            label.GetComponentInChildren<TextMeshProUGUI>().text = pm.playerName;

            GameObject icon = label.transform.Find("HorizontalRow/Icon").gameObject;
            icon.GetComponent<Image>().sprite = defaultIconSprite;



        }

        //ついでに部屋のタイトル表示
        titleText.text = mr.title;



    }

    // Update is called once per frame
    

   
  
}
