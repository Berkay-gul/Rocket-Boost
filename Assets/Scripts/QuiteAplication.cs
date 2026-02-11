using UnityEngine;
using UnityEngine.InputSystem;

public class QuiteAplication : MonoBehaviour
{

    void Update()
    {
        if (Keyboard.current.escapeKey.isPressed)
        {
            Debug.Log("escape pressed");
            Application.Quit();
        }
    }
}
