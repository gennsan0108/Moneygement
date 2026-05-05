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

    public void SetTitle(string title)
    {
        paymentTitle = title;
    }

    public Dictionary<PersonManagement,int> GetPaysMember()
    {
        return paymentMembers;
    }

    public void AddMember(PersonManagement pm, int money)
    {
        paymentMembers[pm] = money;
        totalPayment += money;
    }

    public void RemoveMember(PersonManagement targetPerson)
    {
        if (paymentMembers.TryGetValue(targetPerson, out int money))
        {
            totalPayment -= money;
            paymentMembers.Remove(targetPerson);
        }
    }
    public bool HasMembers()
    {
        return paymentMembers.Count > 0;
    }
}
