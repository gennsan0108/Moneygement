using System;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class MemberListManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private GameObject popupPanel;

    [SerializeField] private GameObject MemberLabel;//メンバー画面のメンバーPrefab
    [SerializeField] private Transform content;//を入れるスクロールバー
    [SerializeField] private Sprite defaultIconSprite;//アイコン仮
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private GameObject paymentPrefab;
    [SerializeField] private Transform paymentContent;


   
    void Start()
    {
        ManagementRoom mr = HomeScreenManager.currentRoom;
        InitMemberDisplauable(mr);
        //ついでに部屋のタイトル表示
        titleText.text = mr.title;

    }
    //メンバーリスト画面のメンバーの表示
    void InitMemberDisplauable(ManagementRoom mr)
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

    //請求作成画面でのメンバーのリスト表示
    void AddPaymentMemberInList(PersonManagement pm)
    {
        GameObject paymentLabel = Instantiate(paymentPrefab, paymentContent);
        paymentLabel.GetComponentInChildren <TextMeshProUGUI>().text = pm.playerName;

        string money = paymentLabel.GetComponentInChildren<TMP_InputField>().text;
        
        
        
    }




}
