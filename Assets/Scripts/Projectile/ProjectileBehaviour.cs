using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class ProjectileBehaviour : MonoBehaviour
{
    [SerializeField] protected ParticleSystem _particlesOnDestroy;
    [SerializeField] private float _shootForce;

    private Transform m_transform;
    private Rigidbody _rb;

    private void Awake()
    {
        m_transform = transform; 
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        #region ComponentNullCheck
        if (!_rb) 
        {
            Debug.LogError(name + "does not have ParticleSystem component, but tries to use It");
            return;
        }
        #endregion

        _rb.velocity = _rb.transform.forward * _shootForce;
    }

    private void OnTriggerEnter(Collider other)
    {
        #region ComponentNullCheck
        if (!_rb)
        {
            Debug.LogError(name + "does not have ParticleSystem component, but tries to use It");
            return;
        }
        #endregion

        var hitImpact = Instantiate<ParticleSystem>(_particlesOnDestroy, m_transform.position, Quaternion.identity);
        hitImpact.transform.localEulerAngles = new Vector3(0f, 0f, -90f);
        Destroy(gameObject);
    }
}
