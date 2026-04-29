using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ManagementRoom
{
    private String roomId;
    private PersonManagement hostPlayer;
    System.Random rand = new System.Random();
    private string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
    private List<PersonManagement> member = new List<PersonManagement>();

    public ManagementRoom(PersonManagement hostPlayer)
    {

        this.roomId = new string(Enumerable.Repeat(chars, 8).Select(s => s[rand.Next(s.Length)]).ToArray());
        Debug.Log(roomId);//後で消す
        this.hostPlayer = hostPlayer;
        member.Add(hostPlayer);
    }

    public void AddMember(PersonManagement joiner)
    {
        member.Add(joiner);
    }
    public List<PersonManagement> MembersListBack()
    {
        return member;
    }
}
