using UnityEngine;
using Pathfinding;

public class EnemyMovement : MonoBehaviour
{
    public Path path;
    public float speed = 2;
    public float nextWaypointDistance = 3;
    private int currentWaypoint = 0;
    public bool reachedEndOfPath;
   
    private Seeker _seeker;
    private Vector3 _targetPosition = new Vector3(20, 0, 20); // GridPosition olabilir
    private CharacterController _controller;

    private void Awake()
    {
        _seeker = GetComponent<Seeker>();
        _controller = GetComponent<CharacterController>();
    }

    private void OnEnable()
    {
        _seeker.pathCallback += OnPathComplete;
    }

    private void OnDisable()
    {
        _seeker.pathCallback -= OnPathComplete;
    }

    private void Start()
    {
        _seeker.StartPath(transform.position, _targetPosition);
    }

    public void OnPathComplete(Path path)
    {
        Debug.Log("A path was calculated. Did it fail with an error? " + path.error);
        if (!path.error)
        {
            this.path = path;
            // Reset the waypoint counter so that we start to move towards the first point in the path
            currentWaypoint = 0;
        }
    }

    public void Update()
    {
        if (path == null) return;
        reachedEndOfPath = false;
        float distanceToWaypoint;
        while (true)
        {
            distanceToWaypoint = Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]);
            if (distanceToWaypoint < nextWaypointDistance)
            {
                if (currentWaypoint + 1 < path.vectorPath.Count)
                {
                    currentWaypoint++;
                }
                else
                {
                    reachedEndOfPath = true;
                    break;
                }
            }
            else
            {
                break;
            }
        }

        float speedFactor = reachedEndOfPath ? Mathf.Sqrt(distanceToWaypoint / nextWaypointDistance) : 1f;
        Vector3 direction = (path.vectorPath[currentWaypoint] - transform.position).normalized;
        Vector3 velocity = direction * speed * speedFactor;
        _controller.SimpleMove(velocity);
    }
}