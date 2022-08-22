using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDoor : MonoBehaviour
{
    public HideZone hide;

    Vector3 ClosePosition;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 ClosePosition = new Vector3(transform.position.x, transform.position.y - 2.5f, transform.position.z);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (hide.DoorClose)
        {
            transform.position = Vector3.Lerp(transform.position, ClosePosition, Time.deltaTime);
        }
    }
}
