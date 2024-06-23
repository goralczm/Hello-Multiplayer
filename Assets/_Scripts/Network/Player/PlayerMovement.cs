using Unity.Netcode;
using UnityEngine;

public class PlayerMovement : NetworkBehaviour
{
    [SerializeField] private float _speed;

    PlayerInput _input;

    private void Start()
    {
        if (!IsOwner)
            return;

        _input = new PlayerInput();
        _input.Player.Enable();
    }

    private void Update()
    {
        if (!IsOwner)
            return;

        Vector2 input = _input.Player.Move.ReadValue<Vector2>();

        transform.position += new Vector3(input.x, 0f, input.y) * _speed * Time.deltaTime;
    }
}
