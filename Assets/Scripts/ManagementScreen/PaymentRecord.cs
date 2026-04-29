using UnityEngine;
using System.Collections.Generic;

public class PaymentRecord : MonoBehaviour
{
    public List<PayPerson> paymentMembers = new List<PayPerson>();
    private string paymentTitle;
    private int totalPayment;

    [System.Serializable]
    public struct PayPerson
    {
        public PersonManagement person;
        public int rate;
    }

    public void RemoveMember(PersonManagement targetPerson)
    {
        paymentMembers.RemoveAll(x => x.person == targetPerson);
    }
}
