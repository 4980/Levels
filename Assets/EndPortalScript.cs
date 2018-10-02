using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPortalScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (GameState.Shooter != null)
            if ((GameState.Shooter.transform.position - this.transform.position).magnitude < 3)
            {
                GameState.WinGameTransition();
            }



    }
}
