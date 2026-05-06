using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HowMuchTag : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private Image spriteIcon;

    public Credit credit { get; private set; }
    public PersonManagement person { get; private set; }

    public void Setup(Credit credit)
    {
        this.person = credit.payee;
        this.credit = credit;
        nameText.text = person.personName;
        spriteIcon.sprite = person.personIcon;
        moneyText.text = "-" +(credit.amount).ToString() + "円";

    }
}
