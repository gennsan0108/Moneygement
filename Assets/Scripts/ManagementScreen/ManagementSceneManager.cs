using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ManagementSceneManager : MonoBehaviour
{
    ManagementRoom mr = HomeScreenManager.currentRoom;
    [SerializeField] private Transform payingMembersContent;//請求リストのContentを取得
    


    public void RemoveMember(PersonManagement person)
    {
        /*ここに削除を本当にするかのモーダルを処理*/

        mr.RemoveMember(person);
        
    }


    public void AddPaymentButton(){

        //Contentの子オブジェクト(請求者メンバー全員)を取得
        foreach(Transform child in payingMembersContent)
        {

        }
    }

    
}
