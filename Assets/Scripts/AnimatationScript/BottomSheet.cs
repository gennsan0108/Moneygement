using UnityEngine;

public class BottomSheet : MonoBehaviour
{
    private Animator animator;
    [SerializeField] Transform content;
    [SerializeField] GameObject prefabInfo;

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

    public void RegisterInfo()
    {
        Transform infoContainer = this.transform.Find("HowMuchList").transform;
        
    }


}
