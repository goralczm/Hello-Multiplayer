using Unity.Netcode;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class NetworkButtons : MonoBehaviour
{
    [SerializeField] private TestRelay _relay;

    private string _joinCode;

    private bool _initialized;
    private bool _isHost;

    private void OnGUI()
    {
        GUILayout.BeginArea(new Rect(0, 0, 300, 80));

        _joinCode = GUILayout.TextField(_joinCode);

        if (!_initialized)
        {
            if (GUILayout.Button("Start Host"))
            {
                _relay.CreateRelay();
                SetJoinCode();
                _initialized = true;
            }

            if (GUILayout.Button("Start Client"))
            {
                _relay.JoinRelay(_joinCode);
                _initialized = true;
            }
        }

        GUILayout.EndArea();
    }

    private async void SetJoinCode()
    {
        _joinCode = await _relay.GetJoinCode();
    }
}
