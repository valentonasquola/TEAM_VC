using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManager : MonoBehaviour
{
    public static PlayerInputManager Instance { get; private set; }
    private AttitudeSensor attitudeSensor = null;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        attitudeSensor = AttitudeSensor.current;
        if (attitudeSensor != null)
        {
            if (!attitudeSensor.enabled)
            {
                InputSystem.EnableDevice(attitudeSensor);
            }
        }
    }
    
    public bool IsGyroEnabled()
    {
        return attitudeSensor != null;
    }

    public Quaternion GetGyroAttitude()
    {
        if (attitudeSensor != null)
        {
            return attitudeSensor.attitude.ReadValue();
        }
        else
        {
            return Quaternion.identity;
        }
    }
}
