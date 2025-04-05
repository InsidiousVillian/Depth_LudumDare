using UnityEngine;

public class Camera_follow : MonoBehaviour
{

    //defines offset from player
    private Vector3 offset = new Vector3(0, 0, -20f);
    private float smoothTime = 0.25f;
    private Vector3 velocity = Vector3.zero;

    [SerializeField] private Transform target;

    // Update is called once per frame
    void Update()
    {
        Vector3 positionOfTarget = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, positionOfTarget, ref velocity, smoothTime);

    }
}
