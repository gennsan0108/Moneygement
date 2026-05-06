using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class PaymentRecord
{
    private Dictionary<PersonManagement, int> paymentMembers = new Dictionary<PersonManagement, int>();
    public string paymentTitle;
    public int totalPayment = 0;
    public CalculatePayMoney calculatePayMoney;
    
    
    public PaymentRecord(List<PersonManagement> pmList)
    {
        foreach(PersonManagement pm in pmList)
        {
            paymentMembers.Add(pm,0);
        }
        calculatePayMoney = new CalculatePayMoney();
        
    }

    //適切に支払い登録されたので支払メンバーに追加する
    public void SetMemberPayment(PersonManagement person, int money)
    {
        paymentMembers[person] = money;
        totalPayment += money;
        
    }
    //ここのメソッドは誰が誰に支払う計算をするのではなく、個人の差し引きを考えている
    public void CalcPayMoneyForEveyone() 
    {
        calculatePayMoney.Calculate(this);
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
