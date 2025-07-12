using UnityEngine;
using Mirror;

public class ZoneController : NetworkBehaviour {
    public Transform zone;
    public float shrinkDelay = 60f;
    public float shrinkAmount = 10f;
    private float timer;

    void Update()
    {
        if (!isServer) return;

        timer += Time.deltaTime;
        if (timer >= shrinkDelay)
        {
            timer = 0f;
            zone.localScale -= Vector3.one * shrinkAmount;
            RpcUpdateZone(zone.localScale);
        }
    }

    [ClientRpc]
    void RpcUpdateZone(Vector3 newScale)
    {
        zone.localScale = newScale;
    }
}