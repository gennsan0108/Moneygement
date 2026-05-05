using TMPro;
using UnityEngine;
using UnityEngine.UI;

// 請求者Prefabの表示と入力を管理する
public class PaymentMemberInput : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private Image spriteIcon;
    [SerializeField] private TMP_InputField moneyInput;

    public PersonManagement Person { get; private set; }

    public void Setup(PersonManagement person)
    {
        Person = person;
        nameText.text = person.personName;
        spriteIcon.sprite = person.personIcon;
        moneyInput.SetTextWithoutNotify("0");
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
