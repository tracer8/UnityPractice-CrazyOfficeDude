using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

    public Image imageDamageEffect;

    private IEnumerator coroutineEffectDamage;
	
    void Awake()
    {
        DisableMeshRender();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            StartCoroutine(TakeDamage(10));
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
        ShowDamageEffect();

        yield return null;
    }

    private void ShowDamageEffect()
    {
        if (coroutineEffectDamage != null)
            StopCoroutine(coroutineEffectDamage);

        coroutineEffectDamage = Coroutine_DamageEffect();
        StartCoroutine(coroutineEffectDamage);
    }

    private IEnumerator Coroutine_DamageEffect()
    {
        imageDamageEffect.gameObject.SetActive(true);
        imageDamageEffect.color = new Color(255, 0, 0, 0.2f);

        float elapsedTime = 0;
        float fadeOutTime = 1.0f;

        Color newColor = imageDamageEffect.color;
        float startAlpha = newColor.a;

        while (true)
        {
            if (elapsedTime >= fadeOutTime)
                break;

            newColor.a = Mathf.Lerp(startAlpha, 0, elapsedTime / fadeOutTime);

            imageDamageEffect.color = newColor;

            elapsedTime += Time.deltaTime;

            yield return null;
        }

        imageDamageEffect.gameObject.SetActive(false);
    }

    private IEnumerator Die()
    {
        GameManager.Instance.IsAllowInput = false;

        GameManager.Notification.PostNotification(this, "OnPlayerDead");

        Debug.LogWarning("Player DEAD!!!!!!");

        yield return new WaitForSeconds(respawnTime);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
