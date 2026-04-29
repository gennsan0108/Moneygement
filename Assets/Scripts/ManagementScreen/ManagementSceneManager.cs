using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ManagementSceneManager : MonoBehaviour
{
    ManagementRoom mr = HomeScreenManager.currentRoom;
    List<PaymentRecord> paymentRecordsList = new List<PaymentRecord>();


    public void RemoveMember(PersonManagement person)
    {
        foreach (PaymentRecord pr in paymentRecordsList)
        {
            pr.RemoveMember(person);
            mr.RemoveMember(person);
        }
    }


    public void ListingPaymentView()
    {

    }
}
