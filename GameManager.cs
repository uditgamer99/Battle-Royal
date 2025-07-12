using UnityEngine;
using Mirror;
using System.Collections.Generic;

public class GameManager : NetworkBehaviour {
    public Transform[] spawnPoints;
    private List<GameObject> players = new List<GameObject>();

    public override void OnStartServer()
    {
        NetworkManager.singleton.OnServerAddPlayer += HandlePlayerJoin;
    }

    void HandlePlayerJoin(NetworkConnection conn)
    {
        Transform start = spawnPoints[Random.Range(0, spawnPoints.Length)];
        GameObject player = Instantiate(NetworkManager.singleton.playerPrefab, start.position, start.rotation);
        NetworkServer.AddPlayerForConnection(conn, player);
        players.Add(player);
    }
}