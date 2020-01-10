using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathEffectControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ParticleSystem.MainModule settings = GetComponent<ParticleSystem>().main;
        settings.startLifetime = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(!GetComponent<ParticleSystem>().IsAlive()){
            Destroy(gameObject);
        }
    }
}
