using UnityEngine;

public class BottomSheet : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Open()
    {
        Debug.Log("open");
        animator.SetBool("isOpen", true);
    }

    public void Close()
    {
        Debug.Log("close");
        animator.SetBool("isOpen", false);
    }

    


}
