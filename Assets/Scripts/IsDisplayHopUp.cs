using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class IsDisplayHopUp : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject popupPanel;

    public GameObject MemberLabel;
    public Transform content;
    public Sprite defaultBackGroundSprite;
    public Sprite defaultIconSprite;
    //public ManagementRoom mr = HomeScreenManager.currentRoom;



    void Start()
    {
        popupPanel.SetActive(false);

        
    }

    // Update is called once per frame
    public void Display()//ホップアップを表示する
    {
        popupPanel.SetActive(true);
        
        ManagementRoom mr = HomeScreenManager.currentRoom;

        List<PersonManagement> PMlist = mr.MembersListBack();
        Debug.Log(content);

        foreach (PersonManagement pm in PMlist)
        {

            GameObject label = Instantiate(MemberLabel, content);
            
            //タグの名前
            label.GetComponentInChildren<TextMeshProUGUI>().text = pm.playerName;
            //タグの背景
            label.GetComponentInChildren<Image>().sprite = defaultBackGroundSprite;

            GameObject icon = label.transform.Find("HorizontalRow/Icon").gameObject;
            icon.GetComponent<Image>().sprite = defaultIconSprite;

            

        }

        


    }

    public void Disapear()
    {
        popupPanel.SetActive(false);
    }
  
}
