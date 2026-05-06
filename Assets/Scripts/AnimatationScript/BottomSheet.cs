using UnityEngine;

public class BottomSheet : MonoBehaviour
{
    private Animator animator;
    private RectTransform rectTransform;
    [SerializeField] private float closedY = -900f;

    void Awake()
    {
        animator = GetComponent<Animator>();
        rectTransform = GetComponent<RectTransform>();
    }

    public void Open()
    {
        Debug.Log("open");
        animator.SetBool("isOpen", true);
    }

    public void Close()
    {
        animator.SetBool("isOpen", false);



        // 見た目の位置を直接閉じ位置に戻す
        Vector2 pos = rectTransform.anchoredPosition;
        pos.y = closedY;
        rectTransform.anchoredPosition = pos;
    }
}

