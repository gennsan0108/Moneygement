using TMPro;
using UnityEngine;
using UnityEngine.UI;


//請求者のPrefabをPersonManagementで固有に割り当てる
public class MemberTag : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private Image spriteIcon;

    public PersonManagement Person { get; private set; }

    public void Setup(PersonManagement person)
    {
        Person = person;
        nameText.text = person.personName;
        spriteIcon.sprite = person.personIcon;
        
    }

   
}
