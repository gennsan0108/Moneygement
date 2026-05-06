using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class ManagementSceneManager : MonoBehaviour
{
    private ManagementRoom mr;
    [SerializeField] private GameObject paymentPrefab;
    [SerializeField] private Transform paymentContent;
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private RecordScreenManager rsm;
    

    private void Start()
    {
        mr = HomeScreenManager.currentRoom;
        titleText.text = mr.title;
        AddPaymentMemberInList(mr);
        
    }

    public void RemoveMember(PersonManagement person)
    {
        /*ここに削除を本当にするかのモーダルを処理*/

        mr.RemoveMember(person);
    }


    public void AddPaymentButton(TMP_InputField title)
    {
        if(title.text == "")
        {
            Debug.LogWarning("タイトルを入力してください");
            return;
        }
        PaymentRecord newRecord = new PaymentRecord(mr.MembersListBack());
        newRecord.paymentTitle = title.text;

        foreach (Transform child in paymentContent)
        {
            PaymentMemberInput memberInput =
                child.GetComponent<PaymentMemberInput>();

            PersonManagement person = memberInput.Person;
            string textMoney = memberInput.GetMoneyText();


            //入力バリデーション
            if (string.IsNullOrWhiteSpace(textMoney))
            {
                Debug.LogWarning("正しい値を入力してください");
                return;
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
            if(money == 0)
            {
                continue;
            }
            //ここまで

            newRecord.SetMemberPayment(person, money);
        }

        if (newRecord.HasPayment())
        {
            Debug.Log("通過");
            mr.AddPayment(newRecord);
            rsm.ViewAddedRecord(newRecord);//支払いをListにて表示する

            ClearPaymentInputs();
        }
        else
        {
            Debug.LogWarning("不合格");
            newRecord = null;
        }
        
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

    private void ClearPaymentInputs()
    {
        foreach (Transform child in paymentContent)
        {
            PaymentMemberInput memberInput = child.GetComponent<PaymentMemberInput>();

            if (memberInput != null)
            {
                memberInput.Clear();
            }
        }
    }

}


