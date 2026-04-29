using UnityEngine;

public class ScreenChanger : MonoBehaviour
{

    public GameObject[] screens;
    public void ChangeManagementScreen(int screenIndex)
    {
        for (int i = 0; i < screens.Length; i++)
        {
            screens[i].SetActive(false);
        }

        screens[screenIndex].SetActive(true);
    }
}
