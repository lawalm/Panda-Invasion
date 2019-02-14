using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles the current and nextwaypoint positions
/// </summary>
public class Waypoint : MonoBehaviour
{
   
    [SerializeField] private Waypoint nextWayPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    /// <summary>
    /// Retrieve the position of the waypoint
    /// </summary>
    /// <returns></returns>
    public Vector3 GetPosition()
    {
        return transform.position;
    }

    /// <summary>
    /// Retrieve the next waypoint in the chain
    /// </summary>
    /// <returns></returns>
    public Waypoint GetNextWaypoint()
    {
        return nextWayPoint;
    }
}
