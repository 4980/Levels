using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{

    [SerializeField] private Shooter ShooterPrefab;
    [SerializeField] private Camera CameraPrefab;
    public static GameObject EveryonesParent = null;
    [SerializeField] private Reader Reader;
    public static Shooter Shooter = null;
    public GameObject SpawnParticleSystem;


    public const int WAIT_GAME_START = 0;
    public const int GAME_ON = 1;
    public const int DYING = 2;
    public const int DEAD = 3;
    public const int WON = 4;

    public static int GAME_STATE = WAIT_GAME_START;


    Camera staticCamera;

    internal static void DieTransition()
    {
        GAME_STATE = DEAD;
        
    }

    public static float TIME_IN_CURRENT_STATE = 0;

    // Start is called before the first frame update
    void Start()
    {
        Reboot();

    }

    void Reboot()
    {
        staticCamera = Instantiate<Camera>(CameraPrefab);
        EveryonesParent = new GameObject("EveryonesParent");
        Reader.Read();
    }

    internal static void WinGameTransition()
    {
        GAME_STATE = WON;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch (GAME_STATE)
        {
            case WAIT_GAME_START:
                UpdateWaitGameState();
                break;
            case WON:
                
                UpdateWonGameState();
                break;
            case DEAD:
                
                UpdateDeadGameState();
                break;
        }

        TIME_IN_CURRENT_STATE += Time.deltaTime;

    }

    private void UpdateWonGameState()
    {
        RemovePlayer();
        if (Input.GetMouseButtonDown(0))
        {
            StartGameTransition();
        }
    }

    private void UpdateWaitGameState()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartGameTransition();
        }
    }

    private void UpdateDeadGameState()
    {
        RemovePlayer();
        if (Input.GetMouseButtonDown(0))
        {
            StartGameTransition();
        }
    }

    private void StartGameTransition()
    {
        GAME_STATE = GAME_ON;
        Destroy(staticCamera, .1f);
        Shooter = Instantiate<Shooter>(ShooterPrefab);
        Shooter.Boot();
        Instantiate(SpawnParticleSystem);
    }

    private void RemovePlayer()
    {
        if (Shooter != null && Shooter.isActiveAndEnabled)
        {
            Destroy(Shooter);
            Destroy(EveryonesParent);
            Reboot();
        }
        
    }
}
