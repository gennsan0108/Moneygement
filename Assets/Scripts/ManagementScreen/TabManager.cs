using System;
using UnityEngine;

public class TabManager : MonoBehaviour
{
    [SerializeField] private Transform[] containers;
    [SerializeField] private GameObject prefab;

    //請求作成画面でのメンバーのリスト表示
    public void OpenTab(PaymentRecord pr, PersonManagement pm)
    {
        int index = ScreenChanger.currentScreenIndex;


        Transform container = containers[index - 1];

        // 1. コンテナの掃除（逆順ループが安全）
        for (int i = container.childCount - 1; i >= 0; i--)
        {
            Destroy(container.GetChild(i).gameObject);
        }

        // 2. 計算結果を取得
        var credits = pr.Calculate(); // Calculateの結果を保持しているリスト

        foreach (Credit credit in credits)
        {
            // pmがnullなら全部表示、pmがいれば「払い手」か「受け手」が一致する場合のみ表示
            if (pm == null || pm == credit.payer || pm == credit.payee)
            {
                GameObject hmPrefab = Instantiate(prefab, container);
                HowMuchTag hmTag = hmPrefab.GetComponent<HowMuchTag>();

                // 表示の出し分け
                if (pm == null)
                {
                    // 全表示モード： 「A → B」の形式で表示
                    hmTag.SetupSummary(credit);
                }
                else if (pm == credit.payer)
                {
                    // 自分が「払い手」の場合： 「Bさんへ -1000円」
                    hmTag.SetupForPayer(credit);
                }
                else if (pm == credit.payee)
                {
                    // 自分が「受け手」の場合： 「Aさんから +1000円」
                    hmTag.SetupForPayee(credit);
                }
            }
        }
    }
}
