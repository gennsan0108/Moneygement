using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class ManagementSceneManager : MonoBehaviour
{
    private ManagementRoom mr;
    private PaymentRecord paymentRecord;
    [SerializeField] private GameObject paymentPrefab;
    [SerializeField] private Transform paymentContent;
    [SerializeField] private Transform payingMembersContent;//請求リストのContentを取得
    

    private void Start()
    {
        mr = HomeScreenManager.currentRoom;
        paymentRecord = new PaymentRecord();
        AddPaymentMemberInList(mr);
        
    }

    public void RemoveMember(PersonManagement person)
    {
        /*ここに削除を本当にするかのモーダルを処理*/

        mr.RemoveMember(person);
    }


    public void AddPaymentButton(TextMeshProUGUI title)
    {
        PaymentRecord newRecord = new PaymentRecord();
        newRecord.SetTitle(title.text);

        foreach (Transform child in paymentContent)
        {
            PaymentMemberInput memberInput =
                child.GetComponent<PaymentMemberInput>();

            PersonManagement person = memberInput.Person;
            string textMoney = memberInput.GetMoneyText();

            if (string.IsNullOrEmpty(textMoney) || textMoney == "0")
            {
                continue;
            }

            if (!int.TryParse(textMoney, out int money))
            {
                Debug.LogWarning("正しい値を入力してください");
                return;
            }

            if (money < 0)
            {
                Debug.LogWarning("金額は0以上で入力してください");
                return;
            }

            newRecord.SetMemberPayment(person, money);
        }

        mr.paymentRecordsList.Add(newRecord);
    }





    void AddPaymentMemberInList(ManagementRoom mr)
    {
        foreach (PersonManagement pm in mr.MembersListBack())
        {
            GameObject paymentLabel = Instantiate(paymentPrefab, paymentContent);

            PaymentMemberInput memberInput =
                paymentLabel.GetComponent<PaymentMemberInput>();

            memberInput.Setup(pm);
        }
    }

    private void UpdatePaymentMember(PersonManagement person, string textMoney)
    {
        if (string.IsNullOrEmpty(textMoney) || textMoney == "0")
        {
            paymentRecord.RemoveMember(person);
            return;
        }

        if (!int.TryParse(textMoney, out int money))
        {
            Debug.LogWarning("正しい値を入力してください");
            paymentRecord.RemoveMember(person);
            return;
        }

        if (money < 0)
        {
            Debug.LogWarning("金額は0以上で入力してください");
            paymentRecord.RemoveMember(person);
            return;
        }

        paymentRecord.SetMemberPayment(person, money);
    }

    private void ClearPaymentInputs()
    {
        foreach (Transform child in paymentContent)
        {
            TMP_InputField input = child.GetComponentInChildren<TMP_InputField>();

            if (input != null)
            {
                input.text = "0";
            }
        }
    }
}


