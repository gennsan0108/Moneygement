using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public List<ManagementGroup> groups = new List<ManagementGroup>();
    public static Action onDataChangedForMember;

    void Awake()
    {
       
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    


}
