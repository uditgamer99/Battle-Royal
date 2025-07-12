using UnityEngine;
using Mirror;

public class PlayerShoot : NetworkBehaviour {
    public Transform gunMuzzle;
    public float range = 100f;
    public float fireRate = 0.1f;
    private float nextFireTime;

    void Update()
    {
        if (!isLocalPlayer) return;

        if (Input.GetButton("Fire1") && Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + fireRate;
            CmdShoot(gunMuzzle.position, gunMuzzle.forward);
        }
    }

    [Command]
    void CmdShoot(Vector3 origin, Vector3 direction)
    {
        RaycastHit hit;
        if (Physics.Raycast(origin, direction, out hit, range))
        {
            Health target = hit.collider.GetComponent<Health>();
            if (target != null)
            {
                target.TakeDamage(25);
            }
        }
        RpcPlayShotFX();
    }

    [ClientRpc]
    void RpcPlayShotFX()
    {
        // play muzzle flash, sound, etc.
    }
}