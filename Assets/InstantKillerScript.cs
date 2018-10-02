using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantKillerScript : MonoBehaviour
{
    public float offset = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float scale = Mathf.Sin(Time.time*offset + offset + .5f);
        this.transform.localScale = new Vector3(scale + 1, scale + 1, scale + 1);
    }
}
