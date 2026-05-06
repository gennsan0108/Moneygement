using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HowMuchTag : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private Image spriteIcon;

    // パターンA：自分が「もらう」側の表示
    public void SetupForPayee(Credit credit)
    {
        // 相手（払ってくれる人）の名前を出す
        PersonManagement person = credit.payer;
        nameText.text = $"{person.personName} から";
        spriteIcon.sprite = person.personIcon;

        moneyText.color = Color.green; // もらうからプラス
        moneyText.text = $"+{credit.amount}円";
    }

    // パターンB：自分が「払う」側の表示
    public void SetupForPayer(Credit credit)
    {
        // 相手（受け取る人）の名前を出す
        PersonManagement person = credit.payee;
        nameText.text = $"{person.personName} へ";
        spriteIcon.sprite = person.personIcon;

        moneyText.color = Color.red; // 払うからマイナス
        moneyText.text = $"-{credit.amount}円";
    }

    // パターンC：全体サマリー表示（pm == null の時）
    public void SetupSummary(Credit credit)
    {
        // 「A → B」という形式で見せる
        nameText.text = $"{credit.payer.personName} → {credit.payee.personName}";
        spriteIcon.sprite = credit.payer.personIcon; // 誰のアイコンにするかはお好みで
        moneyText.color = Color.white;
        moneyText.text = $"{credit.amount}円";
    }
}