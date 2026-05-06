using UnityEngine;

[RequireComponent (typeof(BoxCollider))]
public class Porta : MonoBehaviour
{
    public GameObject door;
    public Vector3 openRotation = new Vector3(0, 120, 0);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
            Open();
    }

    void Open()
    {
        door.transform.localEulerAngles = openRotation;
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Player")
            Close();
    }

    void Close()
    {
        door.transform.localEulerAngles = Vector3.zero;
    }
}
