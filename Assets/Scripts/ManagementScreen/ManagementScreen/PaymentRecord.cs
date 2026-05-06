using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class PaymentRecord
{
    private Dictionary<PersonManagement, int> paymentMembers = new Dictionary<PersonManagement, int>();
    public string paymentTitle;
    public int totalPayment = 0;
   
    private int leftmoney;


    public PaymentRecord(List<PersonManagement> pmList)
    {
        foreach(PersonManagement pm in pmList)
        {
            paymentMembers.Add(pm,0);
        }
        
        
    }

    //適切に支払い登録されたので支払メンバーに追加する
    public void SetMemberPayment(PersonManagement person, int money)
    {
        paymentMembers[person] = money;
        totalPayment += money;
        
    }
    //ここのメソッドは誰が誰に支払う計算をするのではなく、個人の差し引きを考えている
    

    

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

    public List<Credit> Calculate()
    {
        List<Credit> credits = new List<Credit>();

        int count = paymentMembers.Count;//全員の人数
        int total = paymentMembers.Values.Sum();//合計金額
        int average = total / count;
        leftmoney = total % count;


        var creditors = new List<(PersonManagement name, int amount)>();
        var debtors = new List<(PersonManagement name, int amount)>();

        foreach (KeyValuePair<PersonManagement, int> kv in paymentMembers)
        {
            int diff = kv.Value - average;
            if (diff > 0)
            {
                creditors.Add((kv.Key, diff));
            }
            else if (diff < 0)
            {
                debtors.Add((kv.Key, Mathf.Abs(diff)));
            }
        }

        creditors = creditors.OrderByDescending(c => c.amount).ToList();
        debtors = debtors.OrderByDescending(c => c.amount).ToList();

        while (!(creditors.Count == 0) && !(debtors.Count == 0))
        {
            // 常に先頭（一番金額が大きい人）同士を比較
            var creditor = creditors[0];
            var debtor = debtors[0];

            int settleAmount = Mathf.Min(creditor.amount, debtor.amount);

            credits.Add(new Credit(debtor.name, creditor.name, settleAmount));

            // 金額を減らす
            creditor.amount -= settleAmount;
            debtor.amount -= settleAmount;

            // 残額が0になったらリストから削除（次の人へ）
            if (creditor.amount == 0) creditors.RemoveAt(0);
            else creditors[0] = creditor; // 構造体(Tuple)なので値の更新が必要

            if (debtor.amount == 0) debtors.RemoveAt(0);
            else debtors[0] = debtor; // 構造体(Tuple)なので値の更新が必要
        }

        return credits;
    }


}


public class Credit
{
    public PersonManagement payer;
    public PersonManagement payee;
    public int amount;

    public Credit(PersonManagement payer, PersonManagement payee, int amount)
    {
        this.payer = payer;
        this.payee = payee;
        this.amount = amount;
    }
}
