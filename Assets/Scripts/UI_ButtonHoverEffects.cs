using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_ButtonHoverEffects : MonoBehaviour
{
    [SerializeField] private GameObject particles;

    [System.Obsolete]
    private void Awake()
    {
        foreach (ParticleSystem particle in particles.GetComponentsInChildren<ParticleSystem>())
        {
            particle.startColor = new Color(particle.startColor.r, particle.startColor.g, particle.startColor.b, 0);
        }
    }

    private void Start()
    {
        particles.SetActive(true);
    }

    [System.Obsolete]
    public void OnHover()
    {
        foreach (ParticleSystem particle in particles.GetComponentsInChildren<ParticleSystem>())
        {
            particle.startColor = new Color(particle.startColor.r, particle.startColor.g, particle.startColor.b, 1);
        }
    }

    [System.Obsolete]
    public void OnExit()
    {
        foreach (ParticleSystem particle in particles.GetComponentsInChildren<ParticleSystem>())
        {
            particle.startColor = new Color(particle.startColor.r, particle.startColor.g, particle.startColor.b, 0);
        }
    }


}
