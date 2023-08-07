using Unity.Netcode;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovable : NetworkBehaviour
{
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _rotationSpeed;

    private Vector3 _movementDirection;
    private Vector2 _inputAxis;

    private CharacterController _characterController;
    private Transform m_transform;

    public Vector3 MovementDirection => _movementDirection;
    public CharacterController CharacterController => _characterController;
   

    void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        m_transform = transform;
    }

    void Update()
    {
        if (!IsOwner)  
        {
            return;
        }
        #region ComponentNullCheck
        if (!_characterController)
        {
            Debug.LogError(name + "does not have CharacterController component, but tries to use It");
            return;
        }
        #endregion

        _inputAxis.x = Input.GetAxis("Horizontal");
        _inputAxis.y = Input.GetAxis("Vertical");

        _movementDirection = new Vector3(_inputAxis.x, 0, _inputAxis.y);
        _movementDirection.Normalize();

        _characterController.Move(_movementDirection * _movementSpeed * Time.deltaTime);

        if (_movementDirection != Vector3.zero) 
        {
            var toRotation = Quaternion.LookRotation(_movementDirection, Vector3.up);
            m_transform.rotation = Quaternion.RotateTowards(m_transform.rotation, toRotation, _rotationSpeed * Time.deltaTime);
        }
    }
}
