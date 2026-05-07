using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class HomeScreenManager :MonoBehaviour
{
    [SerializeField] private Transform content;
    [SerializeField] private GameObject groupButtonPrefab;
    [SerializeField] private TMP_InputField groupNameInput;
    public static ManagementRoom currentRoom;
    [SerializeField] private Sprite defaultIconSprite;//アイコン仮

    void Start()
    {
       

        foreach (ManagementGroup mg in GameManager.instance.groups)
        {
            
            CreateGroupButton(mg);
        }
    }



    public void addGroup()
    {
        //入力されたタイトルを取得
        string groupName = groupNameInput.text;
        //未入力であれば何もしない
        if (string.IsNullOrEmpty(groupName)) return;

        PersonManagement karidataUser = new PersonManagement("genn",defaultIconSprite);//後で消す
        
        ManagementGroup managementGroup = new ManagementGroup(groupName, karidataUser);

        GameManager.instance.groups.Add(managementGroup);

        CreateGroupButton(managementGroup);

        groupNameInput.text = "";

    }
    void CreateGroupButton(ManagementGroup managementGroup)
    {
        GameObject btn = Instantiate(groupButtonPrefab, content);
        btn.transform.SetAsFirstSibling();//ボタンを上から順にStack
        ManagementRoom mg = managementGroup.managementRoom;
        btn.GetComponent<Button>().onClick.AddListener(() =>
        {
            currentRoom = mg;
            SceneManager.LoadScene("ManagementScene");
        });

        TextMeshProUGUI[] texts = btn.GetComponentsInChildren<TextMeshProUGUI>();
        texts[0].text = managementGroup.groupName;
        texts[1].text = "制作日:" + managementGroup.updateDate.ToString("yyyy/MM/dd");
        texts[2].text = "製作者:" + managementGroup.creationPerson;

    }
    
}

public class ManagementGroup
{
    public string groupName;
    public DateTime updateDate;
    public string creationPerson;
    public ManagementRoom managementRoom;

    public ManagementGroup(string groupName,PersonManagement person)
    {
        this.groupName = groupName;
        this.updateDate = DateTime.Now;
        this.creationPerson = person.personName ;
        this.managementRoom = new ManagementRoom(person, groupName);

    }
    public void ChangeTitle(string fixedTitle)
    {
        this.groupName = fixedTitle;
    }
}
