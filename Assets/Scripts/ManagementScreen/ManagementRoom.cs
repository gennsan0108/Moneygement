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

    public ManagementRoom(PersonManagement hostPlayer, string title)
    {

        this.roomId = new string(Enumerable.Repeat(chars, 8).Select(s => s[rand.Next(s.Length)]).ToArray());
        Debug.Log(roomId);//後で消す
        this.hostPlayer = hostPlayer;
        member.Add(hostPlayer);
        this.title = title;
        this.paymentRecordsList = new List<PaymentRecord>();
    }

    public void AddMember(PersonManagement joiner)
    {
        member.Add(joiner);
    }

    public void RemoveMember(PersonManagement leaver)
    {
        member.Remove(leaver);
        //請求リストに入っている人物の請求も削除
        foreach (PaymentRecord pr in this.paymentRecordsList)
        {
            pr.RemoveMember(leaver);

        }
    }
    public List<PersonManagement> MembersListBack()
    {
        return member;
    }
}
