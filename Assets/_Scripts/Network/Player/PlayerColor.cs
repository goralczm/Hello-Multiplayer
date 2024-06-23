using Unity.Netcode;
using UnityEngine;

public class PlayerColor : NetworkBehaviour
{
    [SerializeField] private Color[] _playerColors;

    private MeshRenderer _rend;

    private void Awake()
    {
        _rend = GetComponent<MeshRenderer>();
    }

    public override void OnNetworkSpawn()
    {
        _rend.material.color = _playerColors[(int)OwnerClientId];
    }
}
