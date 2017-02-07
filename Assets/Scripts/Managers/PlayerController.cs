using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public float respawnTime = 2.0f;

    private float health = 100;
    public float Health
    {
        get
        {
            return health;
        }

        set
        {
            health = value;

            if (health <= 0)
                StartCoroutine(Die());
        }
    }
    private Animator thisAnimator;
	
    void Awake()
    {
        thisAnimator = this.gameObject.GetComponent<Animator>();

        if (thisAnimator != null)
            thisAnimator.enabled = false;

        DisableMeshRender();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            StartCoroutine(TakeDamage(20));
    }

    private void DisableMeshRender()
    {
        MeshRenderer meshRender = this.GetComponentInChildren<MeshRenderer>();
        meshRender.enabled = false;
    }

    private IEnumerator TakeDamage(float damageAmount)
    {
        Health -= damageAmount;

        GameManager.Notification.PostNotification(this, "OnPlayerTakeDamage");

        yield return null;
    }

    private IEnumerator Die()
    {
        GameManager.Instance.IsAllowInput = false;

        GameManager.Notification.PostNotification(this, "OnPlayerDead");

        if (thisAnimator != null)
        {
            thisAnimator.enabled = true;
            thisAnimator.SetTrigger("ShowDeath");
        }

        yield return new WaitForSeconds(respawnTime);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
