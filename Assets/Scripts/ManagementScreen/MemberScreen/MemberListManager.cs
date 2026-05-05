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


    ManagementRoom mr;

   
    void Start()
    {

        mr = HomeScreenManager.currentRoom;
        
        GameManager.onDataChangedForMember += ReViewMemberList;

    }
    //メンバーリスト画面のメンバーの表示
    void InitMemberDisplayable()
    {

        

        foreach (PersonManagement pm in mr.MembersListBack())
        {
     
            GameObject memberLabel = Instantiate(MemberLabel, content);

            MemberTag memberTag = memberLabel.GetComponent<MemberTag>();



            memberTag.Setup(pm);
            


        }
    }
    void ReViewMemberList()
    {
        foreach(Transform child in content)
        {
            Destroy(child);
        }

        InitMemberDisplayable();
    }

    //請求作成画面でのメンバーのリスト表示
    




}
