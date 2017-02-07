using UnityEngine;
using System.Collections;

public class SwitchController : MonoBehaviour {

    public GameObject PCController;
    public GameObject MobileControler;

    void Awake()
    {
#if UNITY_IPHONE || UNITY_ANDROID || UNITY_WP8
        PCController.SetActive(false);
        MobileControler.SetActive(true);
#endif
    }
}
