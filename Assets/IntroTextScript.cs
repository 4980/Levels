using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroTextScript : MonoBehaviour
{
    public string WaitingText = "";
    public string WonText = "";
    public string DeadText = "";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.localScale = Vector3.one;
        switch (GameState.GAME_STATE)
        {
            case GameState.WAIT_GAME_START:
                GetComponent<Text>().text = WaitingText.Replace("\\n", "\n");
                break;
            case GameState.WON:
                GetComponent<Text>().text = WonText.Replace("\\n", "\n");
                break;
            case GameState.DEAD:
                GetComponent<Text>().text = DeadText.Replace("\\n", "\n");
                break;
            default:
                this.transform.localScale = Vector3.zero;
                break;
        }
        
        
    }
}
