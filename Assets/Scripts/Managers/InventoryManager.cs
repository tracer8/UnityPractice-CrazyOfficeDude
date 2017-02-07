using UnityEngine;
using System.Collections;

public class InventoryManager : MonoBehaviour {

	public float totalCash = 1500f;

    private float currentCash = 0f;
    public float Cash
    {
        get
        {
            return currentCash;
        }

        set
        {
            currentCash = value;

            if (currentCash >= totalCash)
                GameManager.Notification.PostNotification(this, "OnCashCollectedAll");

            Debug.Log("Cash: " + currentCash);
        }
    }

}
