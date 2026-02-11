using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CollisiionHandler : MonoBehaviour
{
    // Veriables
    [SerializeField] float LoadDeley =2f;
    [SerializeField] AudioClip SuccesSFX;
    [SerializeField] AudioClip CrashSFX;
    [SerializeField] ParticleSystem  SuccesVFX;
    [SerializeField] ParticleSystem  CrashVFX;
    AudioSource audioSource;
    bool isControllable;
    bool iscollidable;

    void Start()
    {
        isControllable = true;
        iscollidable= true;
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        RespondTheDebugKeys();
    }

    void RespondTheDebugKeys()
    {
        if (Keyboard.current.lKey.wasPressedThisFrame)
        {
            LoadNexLevel();
        }
        else if (Keyboard.current.kKey.wasPressedThisFrame)
        {
            iscollidable = !iscollidable;
            Debug.Log("k pressed");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(!isControllable || !iscollidable ){return;}

        switch (collision.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("louncpad e degdim");
                break;
            case "Finish":
                StartSuccesSeguence();
                break;
            default:
                startCrashSeguence();
                break;
        }

        
    }

    private void StartSuccesSeguence()
    {
        
        isControllable = false;
        audioSource.Stop();
        audioSource.PlayOneShot(SuccesSFX);
        SuccesVFX.Play();
        GetComponent<Movoment>().enabled= false;  
        Invoke("LoadNexLevel", LoadDeley);        
    }

    void startCrashSeguence()
    {
        
        isControllable = false;
        audioSource.Stop();
        audioSource.PlayOneShot(CrashSFX);
        CrashVFX.Play();
        GetComponent<Movoment>().enabled= false;
        Invoke("ReloadLevel" , LoadDeley); 
    }

    void LoadNexLevel()
        {
            int currentlevel = SceneManager.GetActiveScene().buildIndex;
            int nextlevel = currentlevel +1;
            if(nextlevel == SceneManager.sceneCountInBuildSettings)
            {
                nextlevel = 0;
                SceneManager.LoadScene(nextlevel);
            }
            else
            {
                SceneManager.LoadScene(nextlevel);
            }
        }
        void ReloadLevel()
        {
            int currentlevel = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentlevel);

        }
}
