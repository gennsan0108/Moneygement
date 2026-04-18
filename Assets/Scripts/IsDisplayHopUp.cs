using UnityEngine;

public class IsDisplayHopUp : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject popupPanel; 
    void Start()
    {
        popupPanel.SetActive(false);
    }

    // Update is called once per frame
    public void Display()
    {
        popupPanel.SetActive(true);
    }
  
}
