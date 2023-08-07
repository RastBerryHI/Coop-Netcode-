using Unity.Netcode;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimable : NetworkBehaviour
{
    [SerializeField] private string _movementVelocityArgument;
    [SerializeField] private PlayerMovable _playerMovable;
    private Animator _animator;

    private int _movementVelocityHashed;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _movementVelocityHashed = Animator.StringToHash(_movementVelocityArgument);

        _movementVelocityArgument = null;
    }

    void Update()
    {
        if (!IsOwner)
        {
            return;
        }

        #region ComponentNullCheck
        if (!_playerMovable) 
        {
            Debug.LogError(name + "does not have PlayerMovable component, but tries to use It");
            return;
        }

        if (!_animator) 
        {
            Debug.LogError(name + "does not have Animator component, but tries to use It");
            return;
        }
        #endregion

        _animator.SetFloat(_movementVelocityHashed, _playerMovable.MovementDirection.magnitude);
    }
}
