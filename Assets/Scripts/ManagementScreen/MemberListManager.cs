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
    [SerializeField] private TextMeshProUGUI titleText;
   


   
    void Start()
    {
        ManagementRoom mr = HomeScreenManager.currentRoom;
        InitMemberDisplayable(mr);
        //ついでに部屋のタイトル表示
        titleText.text = mr.title;

    }
    //メンバーリスト画面のメンバーの表示
    void InitMemberDisplayable(ManagementRoom mr)
    {
       


        foreach (PersonManagement pm in mr.MembersListBack())
        {
            PersonManagement capturedPm = pm; // キャプチャする変数を作成
            GameObject memberLabel = Instantiate(MemberLabel, content);

            MemberTag memberTag = memberLabel.GetComponent<MemberTag>();



            memberTag.Setup(capturedPm);
            


        }
    }

    //請求作成画面でのメンバーのリスト表示
    




}
