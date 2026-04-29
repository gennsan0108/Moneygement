using UnityEngine;

public class ManagementSceneManager : MonoBehaviour
{
    ManagementRoom mr = HomeScreenManager.currentRoom;

    void AddMember(PersonManagement person)
    {
        mr.AddMember(person);
    }
}
