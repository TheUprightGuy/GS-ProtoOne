using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class PlayerCam : MonoBehaviour
{


    public Vector3 OffSet = Vector3.zero;

    public float SmoothTime = 0.5f;

    public float ZoomLimiter = 30.0f;
    public float MinFoV = 10.0f;
    public float MaxFoV = 50.0f;
    private Vector3 Velocity = Vector3.zero;
    private Camera thisCam;
    private List<Transform> Players;

    void Start()
    {
        thisCam = GetComponent<Camera>();

        Players = new List<Transform>();
        foreach (var item in GameObject.FindGameObjectsWithTag("Player"))
        {
            Players.Add(item.transform);
        }

    }
    // Update is called once per frame
    void LateUpdate()
    {
        ZoomCam();
        MoveCam();
    }

    void MoveCam()
    {
        Vector3 newPos = PlayerBounds().center + OffSet;
        transform.position = Vector3.SmoothDamp(transform.position, newPos, ref Velocity, SmoothTime);
    }

    void ZoomCam()
    {                                               //Greatest Dist
        float newZoom = Mathf.Lerp(MinFoV, MaxFoV, PlayerBounds().size.x / ZoomLimiter);
        thisCam.fieldOfView = Mathf.Lerp(thisCam.fieldOfView, newZoom, Time.deltaTime);
    }

    Bounds PlayerBounds()
    {
        Bounds allPlayers = new Bounds(Players[0].transform.position, Vector3.zero);

        foreach(Transform item in Players)
        {
            allPlayers.Encapsulate(item.position);
        }

        return(allPlayers);
    }
}
