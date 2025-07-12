using UnityEngine;
using Mirror;

public class Health : NetworkBehaviour {
    [SyncVar] public int currentHealth = 100;

    public void TakeDamage(int amount)
    {
        if (!isServer) return;

        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            RpcDie();
        }
    }

    [ClientRpc]
    void RpcDie()
    {
        // disable player or play death animation
        gameObject.SetActive(false);
    }
}