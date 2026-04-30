using TMPro;
using UnityEngine;

public class PaymentMemberInput : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TMP_InputField moneyInput;

    public PersonManagement Person { get; private set; }

    public void Setup(PersonManagement person)
    {
        Person = person;
        nameText.text = person.personName;
        moneyInput.text = "";
    }

    public string GetMoneyText()
    {
        return moneyInput.text;
    }

    public void Clear()
    {
        moneyInput.SetTextWithoutNotify("");
    }
}
