using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using TMPro;
using UnityEngine.UI;
using System;

public class BaseShipController : MonoBehaviour
{
    protected float speed;
    protected NavMeshAgent agent;
    protected Vector3 destination;

    protected List<Vector3> destinations = new List<Vector3>();
    protected List<Vector3> linePoints = new List<Vector3>();

    protected int currentDestinationIndex = 0;

    protected LineRenderer lineRenderer;

    public Image selectedIMG;

 

    protected GeneralShipController shipController;

    protected void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        agent = GetComponentInParent<NavMeshAgent>();

        shipController = GetComponent<GeneralShipController>();
    }

    protected virtual void Update()
    {
        selectedIMG.enabled = shipController.isSelected;

        if (destinations.Count > 0 && !agent.pathPending && agent.remainingDistance < 0.1f)
        {
            MoveToNextDestination();
        }

        UpdateLineRenderer();
    }

    public void SetDestination(Vector3 _destination)
    {
        agent.SetDestination(_destination);
    }

    public void AddDestination(Vector3 destination)
    {
        destinations.Add(destination);
    }

    public void ClearDestinations()
    {
        destinations.Clear();
        linePoints.Clear(); // Clear the linePoints list as well
    }

    private void MoveToNextDestination()
    {
        destinations.RemoveAll(dest => agent.path.corners.Contains(dest));

        if (currentDestinationIndex < destinations.Count)
        {
            SetDestination(destinations[currentDestinationIndex]);
            currentDestinationIndex++;
        }
        else
        {
            destinations.Clear();
            currentDestinationIndex = 0;
        }
    }

    private void UpdateLineRenderer()
    {
        linePoints.Clear(); // Clear the linePoints list

        if (agent.hasPath)
        {
            linePoints.AddRange(agent.path.corners);
        }

        linePoints.AddRange(destinations);

        lineRenderer.positionCount = linePoints.Count;
        lineRenderer.SetPositions(linePoints.ToArray());
    }
}
