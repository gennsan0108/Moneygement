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
        calculatePayMoney = new CalculatePayMoney(paymentMembers);
        
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
        calculatePayMoney.Calculate();
    }

    

    public Dictionary<PersonManagement,int> GetPaysMember()
    {
        return paymentMembers;
    }

    public void AddMember(PersonManagement joiner)
    {
        paymentMembers.Add(joiner, 0);
    }


    public bool HasPaid(PersonManagement person)
    {
        return paymentMembers.ContainsKey(person) && paymentMembers[person] > 0;
    }

    public void RemoveMember(PersonManagement person)
    {
        if (paymentMembers.ContainsKey(person))
        {
            totalPayment -= paymentMembers[person];
            paymentMembers.Remove(person);
        }
    }

    public bool HasPayment()
    {
        return paymentMembers.Values.Any(money => money > 0);
    }


    public void CombinePayment(PaymentRecord otherPayment,bool plus)
    {
        int sign = 1;
        if (!plus) sign = -1;
        foreach (var kvOther in otherPayment.GetPaysMember())
        {
            var person = kvOther.Key;
            var money = kvOther.Value;

            if (paymentMembers.ContainsKey(person))
            {
                // すでにいる人の場合は加算
                paymentMembers[person] += money*sign;
            }
            

            // 合計金額もしっかり更新
            totalPayment += money*sign;
        }

    }


}
