using UnityEngine;

public class Oscilattor : MonoBehaviour
{
    [SerializeField] Vector3 MovementVector;
    [SerializeField] float speed;
     Vector3 StartPosition ;
     Vector3 EndPosition;
    float movementFactor;
    void Start()
    {
        StartPosition = transform.position;
        EndPosition = StartPosition + MovementVector;
    }
    void Update()
    {
        movementFactor = Mathf.PingPong(Time.time*speed,1f);
        transform.position = Vector3.Lerp(StartPosition, EndPosition, movementFactor);
    }
}
