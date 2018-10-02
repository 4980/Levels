using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBarScript : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameState.Shooter != null)
            this.transform.localScale = new Vector3(GameState.Shooter.shield, 1, 1);
        else
        {
            this.transform.localScale = Vector3.zero;
        }

    }
}
