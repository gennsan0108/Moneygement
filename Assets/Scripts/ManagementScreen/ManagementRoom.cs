using System;
using System.Collections.Generic;
using System.Linq;
using TreeEditor;
using UnityEngine;

public class ManagementRoom
{
    private String roomId;
    private PersonManagement hostPlayer;
    System.Random rand = new System.Random();
    private string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
    private List<PersonManagement> member = new List<PersonManagement>();
    public String title;
    public List<PaymentRecord> paymentRecordsList;
    public  PaymentRecord totalPayment { get; private set; }
    public int totalAmount;

    public ManagementRoom(PersonManagement hostPlayer, string title)
    {

        this.roomId = new string(Enumerable.Repeat(chars, 8).Select(s => s[rand.Next(s.Length)]).ToArray());
        this.hostPlayer = hostPlayer;
        PersonManagement karidataUser2 = new PersonManagement("gen2", null);//後で消す
        PersonManagement karidataUser3 = new PersonManagement("genn3", null);//後で消す
        member.Add(hostPlayer);
        member.Add(karidataUser2);
        member.Add(karidataUser3);
        this.title = title;
        this.paymentRecordsList = new List<PaymentRecord>();
        this.totalAmount = 0;
        totalPayment = new PaymentRecord(member);
    }

    public void AddMember(PersonManagement joiner)
    {
        member.Add(joiner);
        foreach(PaymentRecord pr in paymentRecordsList)
        {
            pr.AddMember(joiner);
        }
        totalPayment.AddMember(joiner);
    }

    public void RemoveMember(PersonManagement leaver)
    {
        for (int i = paymentRecordsList.Count - 1; i >= 0; i--)
        {
            PaymentRecord pr = paymentRecordsList[i];

            if (pr.HasPaid(leaver))
            {
                totalPayment.CombinePayment(pr, false);
                totalAmount -= pr.totalPayment;
                paymentRecordsList.RemoveAt(i);
            }
            else
            {
                pr.RemoveMember(leaver);
            }
        }

        totalPayment.RemoveMember(leaver);
        member.Remove(leaver);

        GameManager.onDataChangedForMember?.Invoke();
    }


    public List<PersonManagement> MembersListBack()
    {
        return member;
    }

    //支払いをListに追加して、合計支払に加算する
    public void AddPayment(PaymentRecord payment)
    {

        this.totalPayment.CombinePayment(payment,true);
        paymentRecordsList.Add(payment);
        totalAmount += payment.totalPayment;


    }
}
