using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class ParticleDestroyer : MonoBehaviour
{
    private ParticleSystem _particles;

    private void Awake()
    {
        _particles = GetComponent<ParticleSystem>();
    }

    void Start()
    {
        #region ComponentNullCheck
        if (!_particles) 
        {
            Debug.LogError(name + "does not have ParticleSystem component, but tries to use It");
            return;
        }
        #endregion

        if (!_particles.main.loop) 
        {
            Destroy(gameObject, _particles.main.duration);
        }
    }
}
