using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Tooltip("Posizione nel mondo del gioco della telecamera")]
    [SerializeField] Transform cameraPosition;
        
    private void Update()
    {
        if (PlayerInputManager.Instance.IsGyroEnabled())
        {
            transform.position = cameraPosition.position;
            var attitudeValue = PlayerInputManager.Instance.GetGyroAttitude();
            transform.rotation = Quaternion.Euler(90, 0, 0) * GyroToUnity(attitudeValue);
        }
        else
        {
            transform.position = cameraPosition.position;
            transform.rotation = cameraPosition.rotation;
        }
    }

    private static Quaternion GyroToUnity(Quaternion q)
    {
        return new Quaternion(q.x, q.y, -q.z, -q.w);
    }

}
