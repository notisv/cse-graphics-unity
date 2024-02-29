using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionPlanet : MonoBehaviour
{
    public ParticleSystem planetParticles;
    public ParticleSystem meteorParticles;
    public AudioSource collisionSound;

    void OnCollisionEnter(Collision collision)
    {
        //destroy meteor on impact
        collisionSound.Play();
        meteorParticles.transform.position = collision.gameObject.transform.position;
        meteorParticles.Play();
        GameObject.Destroy(collision.gameObject);

        //destroy the gameObject(planet) if its not the Sun
        if (gameObject.name != "Sun") 
        {         
            planetParticles.Play();
            GameObject.Destroy(gameObject);
        }
    }
}