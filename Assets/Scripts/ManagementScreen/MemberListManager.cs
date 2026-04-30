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
       


        foreach (PersonManagement pm in mr.MembersListBack())
        {
            PersonManagement capturedPm = pm; // キャプチャする変数を作成
            GameObject label = Instantiate(MemberLabel, content);

            //タグの名前
            label.GetComponentInChildren<TextMeshProUGUI>().text = capturedPm.personName;

            GameObject icon = label.transform.Find("HorizontalRow/Icon").gameObject;
            icon.GetComponent<Image>().sprite = defaultIconSprite;


            //ついでに請求者のListを表示
            


        }
    }

    //請求作成画面でのメンバーのリスト表示
    




}
