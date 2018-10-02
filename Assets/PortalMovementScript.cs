using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalMovementScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPosition = this.transform.localPosition;
        currentPosition.y = Mathf.Cos(Time.time * 2);
        this.transform.localPosition = currentPosition;

       



    }
}
