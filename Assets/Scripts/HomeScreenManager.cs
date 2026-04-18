using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class HomeScreenManager :MonoBehaviour
{
    public Transform content;
    public GameObject groupButtonPrefab;
    public TMP_InputField groupNameInput;
    public static ManagementGroup currentGroup;
    
    

    private List<ManagementGroup> groups = new List<ManagementGroup>();

    public void addGroup()
    {
        string groupName = groupNameInput.text;
        if (string.IsNullOrEmpty(groupName)) return;

        PersonManagement karidataUser = new PersonManagement("genn");
        ManagementGroup managementGroup = new ManagementGroup(groupName, karidataUser);

        groups.Add(managementGroup);

        GameObject btn = Instantiate(groupButtonPrefab, content);
        btn.transform.SetAsFirstSibling();//ボタンを上から順にStack
        ManagementGroup mg = managementGroup;
        btn.GetComponent<Button>().onClick.AddListener(() =>
        {
            HomeScreenManager.currentGroup = mg;
            SceneManager.LoadScene("ManagementScene");
        });

        TextMeshProUGUI[] texts = btn.GetComponentsInChildren<TextMeshProUGUI>();
        texts[0].text = managementGroup.groupName;
        texts[1].text = "制作日:" + managementGroup.updateDate.ToString("yyyy/MM/dd");
        texts[2].text = "製作者:" + managementGroup.creationPerson;

        groupNameInput.text = "";

    }
    
}

public class ManagementGroup
{
    public string groupName;
    public DateTime creationDate;
    public DateTime updateDate;
    public string creationPerson;
    public ManagementRoom managementRoom;

    public ManagementGroup(string groupName,PersonManagement person)
    {
        this.groupName = groupName;
        this.creationDate = DateTime.Now;
        this.updateDate = DateTime.Now;
        this.creationPerson = person.playerName ;
        this.managementRoom = new ManagementRoom(person);

    }
    public void ChangeTitle(string fixedTitle)
    {
        this.groupName = fixedTitle;
    }
}
