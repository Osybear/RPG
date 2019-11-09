using UnityEngine;
using UnityEngine.UI;

public class BasicHealth : MonoBehaviour
{   
    public Camera mainCamera;
    public GameObject healthBarPrefab;
    public GameObject healthBar;
    public RectTransform canvas;
    public Image healthImage;
    public Vector3 healthBarOffset;
    public int maxHealth;
    public int currentHealth;

    private void Start() {
        healthBar = Instantiate(healthBarPrefab);
        healthImage = healthBar.transform.Find("Health").GetComponent<Image>();
        healthBar.transform.SetParent(canvas);
    }

    private void Update() {
        SetHealthBarPosition();
    }

    public void Damage(int amount) {
        currentHealth -= amount;
        SetHealthImage();

        if(currentHealth <= 0) {
            Debug.Log(gameObject.name + " has died. Spawn lootable object");
        }
    }

    public void SetHealthImage() {
        healthImage.fillAmount = (float)currentHealth / (float)maxHealth;
    }
    
    public void SetHealthBarPosition() {
        healthBar.transform.position = mainCamera.WorldToScreenPoint(transform.position + healthBarOffset);
    }
}
