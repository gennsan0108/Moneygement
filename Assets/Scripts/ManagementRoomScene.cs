using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagementRoomScene : MonoBehaviour
{

    public void BackToHomeScreen()
    {
        SceneManager.LoadScene("HomeScene");
    }
    
}
