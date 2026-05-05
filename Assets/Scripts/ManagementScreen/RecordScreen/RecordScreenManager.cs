using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RecordScreenManager : MonoBehaviour
{
    [SerializeField] private Transform content;
    [SerializeField] private GameObject paysMembers;
    [SerializeField] private GameObject recordPrefab;

    void Start()
    {
        
    }

    // Update is called once per frame
    public void ViewAddedRecord(PaymentRecord pr) 
    {
        //タイトル表示
        GameObject record = Instantiate(recordPrefab, content);
        record.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = pr.paymentTitle;
        foreach(KeyValuePair<PersonManagement,int> pair in pr.GetPaysMember())
        {
            GameObject paysMember = Instantiate(paysMembers, record.transform.GetChild(1));
            paysMember.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = pair.Key.personIcon;
            paysMember.GetComponentInChildren<TextMeshProUGUI>().text = pair.Key.personName +"       " + pair.Value.ToString() + "円";
        }
       
    }
}
