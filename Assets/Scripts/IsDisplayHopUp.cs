using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IsDisplayHopUp : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject popupPanel;

    public GameObject MemberLabel;
    public Transform content;
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
            TextMeshProUGUI tmp = label.GetComponentInChildren<TextMeshProUGUI>();
            Debug.Log("TMP: " + tmp);
            tmp.text = pm.playerName;

            label.GetComponentInChildren<TextMeshProUGUI>().text = pm.playerName;

        }

        


    }
  
}
