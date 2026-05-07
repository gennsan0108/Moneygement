using UnityEngine;
using UnityEngine.UI;


public class MemberListManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private GameObject informationTab;

    [SerializeField] private GameObject MemberLabel;//メンバー画面のメンバーPrefab
    [SerializeField] private Transform content;//を入れるスクロールバー
    [SerializeField] private TabManager tabManager;


    ManagementRoom mr;

   
    void Start()
    {

        mr = HomeScreenManager.currentRoom;
        InitMemberDisplayable();
        
        GameManager.onDataChangedForMember += ReViewMemberList;//再描写のためにメソッドを登録する

    }
    //メンバーリスト画面のメンバーの表示
    void InitMemberDisplayable()
    {

        

        foreach (PersonManagement pm in mr.MembersListBack())
        {
     
            GameObject memberLabel = Instantiate(MemberLabel, content);

            MemberTag memberTag = memberLabel.GetComponent<MemberTag>();
            memberTag.Setup(pm);
            Button btn = memberLabel.GetComponentInChildren<Button>();
            btn.onClick.AddListener(() =>
            {
                PersonManagement capturedPm = pm;
                
                tabManager.OpenTab(mr.totalPayment, capturedPm);//ある支払いのある人が支払わなければならない時のPrefab追加
                informationTab.GetComponent<BottomSheet>().Open();

            });

        }
    }
    //メンバーに変更があった時に再描写する
    void ReViewMemberList()
    {
        foreach(Transform child in content)
        {
            Destroy(child);
        }

        InitMemberDisplayable();
    }

    
   
    




}
