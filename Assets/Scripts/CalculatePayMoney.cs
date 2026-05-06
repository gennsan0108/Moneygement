using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class CalculatePayMoney
{
    private int leftmoney;
    
    Dictionary<PersonManagement,int> pmList;

    public CalculatePayMoney(Dictionary<PersonManagement,int> pmList)
    {
        this.pmList = pmList;
    }

    //誰が払うかを抽出し、いくら払うかはpayPerOnePersonで決める
    public List<Credit> Calculate()
    {
        List<Credit>credits = new List<Credit>();

        int count = pmList.Count;//全員の人数
        int total = pmList.Values.Sum();//合計金額
        int average = total / count;
        leftmoney = total % count;


        var creditors = new List<(PersonManagement name, int amount)>();
        var debtors = new List<(PersonManagement name, int amount)>();

        foreach (KeyValuePair<PersonManagement, int> kv in pmList)
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

        while(!(creditors.Count == 0) && !(debtors.Count == 0)){
            // 常に先頭（一番金額が大きい人）同士を比較
            var creditor = creditors[0];
            var debtor = debtors[0];

            int settleAmount = Mathf.Min(creditor.amount, debtor.amount);

            credits.Add(new Credit(debtor.name,creditor.name,settleAmount));

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
