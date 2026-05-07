using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ScreenChanger : MonoBehaviour
{

    public static int currentScreenIndex = 0;
    [SerializeField] private BottomSheet informationTab;

    void Start()
    {
        // 最初の画面を表示
        ChangeManagementScreen(currentScreenIndex);
    }

    [SerializeField] private GameObject[] screens;
    public void ChangeManagementScreen(int screenIndex)
    {
        
            informationTab.Close();
            
        



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
    bool isTouching = false;

    void Update()
    {
#if UNITY_EDITOR
        if (Mouse.current != null)
        {
            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                startPos = Mouse.current.position.ReadValue();
                isTouching = true;
            }

            if (Mouse.current.leftButton.wasReleasedThisFrame && isTouching)
            {
                endPos = Mouse.current.position.ReadValue();
                isTouching = false;
                CheckSwipe();
            }
        }
#else
    if (Touchscreen.current != null)
    {
        var touch = Touchscreen.current.primaryTouch;

        if (touch.press.wasPressedThisFrame)
        {
            startPos = touch.position.ReadValue();
            isTouching = true;
        }

        if (touch.press.wasReleasedThisFrame && isTouching)
        {
            endPos = touch.position.ReadValue();
            isTouching = false;
            CheckSwipe();
        }
    }
#endif
    }

    void CheckSwipe()
    {
        float swipeX = startPos.x - endPos.x;

        // 左スワイプ
        if (swipeX > 300 && currentScreenIndex < screens.Length - 1)
        {
            ChangeManagementScreen(currentScreenIndex + 1);
        }
        // 右スワイプ
        else if (swipeX < -300 && currentScreenIndex > 0)
        {
            ChangeManagementScreen(currentScreenIndex - 1);
        }
    }




}
