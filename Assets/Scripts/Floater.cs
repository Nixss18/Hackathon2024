using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Floater : MonoBehaviour
{
    public Rigidbody floaterRigidbody;
    // public AudioSource splashSrc;
    // public GameObject splashParticle;
    // public AudioClip splashClip;
    public float depthBeforeSubmerged = 0.5f;
    public float displacementAmount = 5f;
    public float waterDepth = 0.09f;
    public int floaterCount = 1;
    public float waterDrag = 0.99f;
    public float waterAngularDrag = 0.5f;
    // private bool splashedFirst = false;

    // Update is called once per frame
    void FixedUpdate()
    {
        floaterRigidbody.AddForceAtPosition(Physics.gravity / floaterCount, transform.position, ForceMode.Acceleration);
        float waveHeight = WaveManager.instance.GetWaveHeight(transform.position.x);
        if (transform.position.y < waveHeight)
        {
            // floaterRigidbody.drag = 5f;
            // floaterRigidbody.angularDrag = 0.05f;
            // if (!splashedFirst)
            // {
            //     splashSrc.PlayOneShot(splashClip);
            //     Splash();
            //     splashedFirst = true;
            // }
            float displacementMultiplier = Mathf.Clamp01((waveHeight - transform.position.y) / depthBeforeSubmerged) * displacementAmount;
            floaterRigidbody.AddForceAtPosition(new Vector3(0f, Mathf.Abs(Physics.gravity.y) * displacementMultiplier, 0f), transform.position, ForceMode.Acceleration);
            floaterRigidbody.AddForce(displacementMultiplier * -floaterRigidbody.velocity * waterDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);
            floaterRigidbody.AddTorque(displacementMultiplier * -floaterRigidbody.angularVelocity * waterAngularDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);
        }
    }

    // void Splash()
    // {
    //     GameObject splashPart = Instantiate(splashParticle, transform.position, Quaternion.identity);
    //     splashPart.GetComponent<ParticleSystem>().Play();
    // }
}
