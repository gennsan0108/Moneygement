using TMPro;
using UnityEngine;


//請求者のPrefabをPersonManagementで固有に割り当てる
public class PaymentMemberInput : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TMP_InputField moneyInput;

    public PersonManagement Person { get; private set; }

    public void Setup(PersonManagement person)
    {
        Person = person;
        nameText.text = person.personName;
        moneyInput.text = "0";
    }

    public string GetMoneyText()
    {
        return moneyInput.text;
    }

    public void Clear()
    {
        moneyInput.SetTextWithoutNotify("0");
    }
}
