using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class UIController : MonoBehaviour {
    public Text healthText;
    public Health playerHealth;

    void Update()
    {
        if (playerHealth != null)
        {
            healthText.text = "HP: " + playerHealth.currentHealth;
        }
    }
}