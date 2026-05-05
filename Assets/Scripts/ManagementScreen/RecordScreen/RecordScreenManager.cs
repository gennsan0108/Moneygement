using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RecordScreenManager : MonoBehaviour
{
    [SerializeField] private Transform content;
    [SerializeField] private GameObject paysMembers;
    [SerializeField] private GameObject recordPrefab;
    [SerializeField] private TextMeshProUGUI totalMoney;
    ManagementRoom mr;

    void Start()
    {
        GameManager.onDataChangedForMember = ReViewAllRecord;//再描写のためにメソッドを登録する
        mr = HomeScreenManager.currentRoom;
        totalMoney.text = "0円";
    }

    
    public void ViewAddedRecord(PaymentRecord pr) 
    {
        //タイトル表示
        GameObject record = Instantiate(recordPrefab, content);
        record.GetComponentInChildren<TextMeshProUGUI>().text = pr.paymentTitle;
        Transform memberContainer = record.transform.Find("MemberContainer");
        totalMoney.text = "合計" + mr.totalAmount.ToString() +"円";
        foreach (KeyValuePair<PersonManagement,int> pair in pr.GetPaysMember())
        {
            GameObject paysMember = Instantiate(paysMembers, memberContainer);
            paysMember.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = pair.Key.personIcon;
            paysMember.GetComponentInChildren<TextMeshProUGUI>().text = pair.Key.personName +"       " + pair.Value.ToString() + "円";
            
        }
       
    }

    //メンバーが更新されたときにすべて再描写する
    public void ReViewAllRecord()
    {
        
        foreach(Transform child in content)//いったんすべて消し
        {
            Destroy(child);
        }

        foreach(PaymentRecord pr in mr.paymentRecordsList)//一つ一つ戻す
        {
            ViewAddedRecord(pr);
        }

    }
}
