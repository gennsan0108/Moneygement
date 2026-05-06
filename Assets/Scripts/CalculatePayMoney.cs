using System.Collections.Generic;
using UnityEngine;

public class CalculatePayMoney
{
    public List<PersonManagement>shouldPayMember;
    public List<PersonManagement> shouldBePaidMember;
    private int payPerOnePerson;
    private int leftmoney;

    public CalculatePayMoney()
    {
        shouldPayMember = new List<PersonManagement>();
        shouldBePaidMember = new List<PersonManagement>();
    }

    //誰が払うかを抽出し、いくら払うかはpayPerOnePersonで決める
    public void Calculate(PaymentRecord record)
    {
        
        Dictionary<PersonManagement, int> payMembers = record.GetPaysMember();
        payPerOnePerson = record.totalPayment / payMembers.Count;
        leftmoney = record.totalPayment % payMembers.Count;
        Debug.Log(payPerOnePerson);
        foreach(KeyValuePair<PersonManagement,int> kv in payMembers)
        {
            if(kv.Value - payPerOnePerson < 0)
            {
                Debug.Log(kv.Key);
                shouldPayMember.Add(kv.Key);
            }
            else if(kv.Value - payPerOnePerson > 0)
            {
                shouldBePaidMember.Add(kv.Key);
            }
        }
    }

    
}
