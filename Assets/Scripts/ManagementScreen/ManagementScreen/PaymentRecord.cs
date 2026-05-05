using UnityEngine;
using System.Collections.Generic;

public class PaymentRecord
{
    private Dictionary<PersonManagement, int> paymentMembers = new Dictionary<PersonManagement, int>();
    public string paymentTitle;
    public int totalPayment = 0;
    



    public void SetMemberPayment(PersonManagement person, int money)
    {
        RemoveMember(person);

        if (money <= 0) return;

        paymentMembers.Add(person, money);
        totalPayment += money;
    }

    

    public Dictionary<PersonManagement,int> GetPaysMember()
    {
        return paymentMembers;
    }

    //Dictのキーからpairを削除し、合計金額を差し引く
    public void AddMember(PersonManagement pm, int money)
    {
        paymentMembers[pm] = money;
        totalPayment += money;
    }

    //削除する人の中に支払人がいても削除
    public void RemoveMember(PersonManagement targetPerson)
    {
        if (paymentMembers.TryGetValue(targetPerson, out int money))
        {
            totalPayment -= money;
            paymentMembers.Remove(targetPerson);
        }
        //Memberを含むList表示のものを再描写
        GameManager.onDataChangedForMember?.Invoke();
    }
    public bool HasMembers()
    {
        return paymentMembers.Count > 0;
    }

   
}
