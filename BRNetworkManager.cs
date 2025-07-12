using Mirror;

public class BRNetworkManager : NetworkManager {
    public override void OnServerDisconnect(NetworkConnection conn) {
        base.OnServerDisconnect(conn);
    }
}