using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ScreenChanger : MonoBehaviour
{

    private int currentScreenIndex = 0;

    void Start()
    {
        // 最初の画面を表示
        ChangeManagementScreen(0);
    }

    public GameObject[] screens;
    public void ChangeManagementScreen(int screenIndex)
    {
        for (int i = 0; i < screens.Length; i++)
        {
            screens[i].SetActive(false);
        }
        currentScreenIndex = screenIndex;
        screens[screenIndex].SetActive(true);
    }

    public void BackToHomeScreen()
    {
        SceneManager.LoadScene("HomeScene");
    }

    

    Vector2 startPos;
    Vector2 endPos;

    void Update()
    {
        // マウス（エディター・PC）
        if (Mouse.current != null)
        {
            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                startPos = Mouse.current.position.ReadValue();
            }
            if (Mouse.current.leftButton.wasReleasedThisFrame)
            {
                endPos = Mouse.current.position.ReadValue();
                CheckSwipe();
            }
        }

        // タッチ（実機）
        if (Touchscreen.current != null && Touchscreen.current.touches.Count > 0)
        {
            var touch = Touchscreen.current.touches[0];
            if (touch.phase.ReadValue() == UnityEngine.InputSystem.TouchPhase.Began)
            {
                startPos = touch.position.ReadValue();
            }
            if (touch.phase.ReadValue() == UnityEngine.InputSystem.TouchPhase.Ended)
            {
                endPos = touch.position.ReadValue();
                CheckSwipe();
            }
        }


    }
    void CheckSwipe()
    {
        
        //左スワイプ
        if (startPos.x - endPos.x > 300 && currentScreenIndex < screens.Length - 1)
        {
            ChangeManagementScreen(currentScreenIndex + 1);
        }
        //右スワイプ
        if (startPos.x - endPos.x < -300 && currentScreenIndex > 0)
        {
            ChangeManagementScreen(currentScreenIndex - 1);
        }
    }
}
