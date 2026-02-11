using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Movoment : MonoBehaviour
{
    [SerializeField] InputAction Trust;
    [SerializeField] InputAction Rotation;
    [SerializeField] float TrustForce;
    [SerializeField] float RotateForce;
    [SerializeField] AudioClip Enginesfx;
    [SerializeField] ParticleSystem MainEngineVFX;
    [SerializeField] ParticleSystem RightEngineVFX;
    [SerializeField] ParticleSystem LeftEngineVFX;
    Rigidbody rb;
    AudioSource audioSource;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }
    void OnEnable()
    {
        Trust.Enable();
        Rotation.Enable();
    }
    void FixedUpdate()
    {
        ProcessTrust();
        ProcessRotation();
    }

    void ProcessTrust()
    {
        if (Trust.IsPressed())
        {
            MainEngineVFX.Play();
            rb.AddRelativeForce(Vector3.up * Time.fixedDeltaTime * TrustForce);
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(Enginesfx);
            }
        }
        else
        {
            audioSource.Stop();
        }
    }
     void ProcessRotation()
    {
        float RotValue = Rotation.ReadValue<float>();
        if (RotValue < 0)
        {
            RotateApply(RotateForce);
            RightEngineVFX.Play();
        }
        else if (RotValue > 0)
        {
            RotateApply(-RotateForce);
            LeftEngineVFX.Play();
        }

       
    }

    private void RotateApply(float Direction)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * Direction*Time.fixedDeltaTime);
        rb.freezeRotation = false;
    }
}

