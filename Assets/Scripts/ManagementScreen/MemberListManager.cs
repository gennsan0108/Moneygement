using System;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
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
    public GameObject togglePrefab;
    public Transform paymentContent;


    public ManagementRoom mr = HomeScreenManager.currentRoom;
    void Start()
    {
        InitMemberDisplauable();
        //ついでに部屋のタイトル表示
        titleText.text = mr.title;



    }
    void InitMemberDisplauable()
    {
        List<PersonManagement> PMlist = mr.MembersListBack();


        foreach (PersonManagement pm in PMlist)
        {
            PersonManagement capturedPm = pm; // キャプチャする変数を作成
            GameObject label = Instantiate(MemberLabel, content);

            //タグの名前
            label.GetComponentInChildren<TextMeshProUGUI>().text = capturedPm.playerName;

            GameObject icon = label.transform.Find("HorizontalRow/Icon").gameObject;
            icon.GetComponent<Image>().sprite = defaultIconSprite;


            //ついでに請求者のListを表示
            AddPaymentMemberInList(capturedPm);


        }
    }

    
    void AddPaymentMemberInList(PersonManagement pm)
    {
        GameObject paymentLabel = Instantiate(togglePrefab, paymentContent);
        paymentLabel.GetComponentInChildren<Text>().text = pm.playerName;

        string money = paymentLabel.GetComponentInChildren<TMP_InputField>().text;
        
        
        
    }

    // Update is called once per frame




}
