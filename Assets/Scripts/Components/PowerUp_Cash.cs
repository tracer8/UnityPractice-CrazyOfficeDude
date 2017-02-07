using UnityEngine;
using System.Collections;

public class PowerUp_Cash : MonoBehaviour {

    public float cashPerCollect = 0f;
    public AudioSource audioSource = null;
    public AudioClip sound;

	// Use this for initialization
	void Start ()
    {
        GameObject audioObject = GameObject.FindGameObjectWithTag("AudioSource");

        if (audioObject == null)
            return;

        audioSource = audioObject.GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        PlayEffectSound();
        IncreaseCash();
        DisappearCash();

        GameManager.Notification.PostNotification(this, "OnPowerupCollected");
    }
    
    private void PlayEffectSound()
    {
        if (audioSource == null)
            return;

        audioSource.PlayOneShot(this.sound);
    }

    private void IncreaseCash()
    {

    }

    private void DisappearCash()
    {
        this.gameObject.SetActive(false);
    }
	
}
