using UnityEngine;
using UnityEngine.AI;

public class WatcherFSM1 : MonoBehaviour
{
    private enum WatcherState { Idle, CloseToPlayer, KillPlayer }
    private WatcherState currentState = WatcherState.Idle;

    public Transform player;
    private NavMeshAgent agent;

    [Header("Watcher Settings")]
    public float detectionDistance = 15f;
    public float killDistance = 5f;
    public float moveSpeed = 2f;
    public float timeToKill = 3f;

    private float closeTimer = 0f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = moveSpeed;

        MeshRenderer[] meshes = GetComponentsInChildren<MeshRenderer>();
        foreach (var mesh in meshes)
        {
            mesh.enabled = false; // Hide Watcher
        }
    }

    void Update()
    {
        switch (currentState)
        {
            case WatcherState.Idle:
                IdleBehavior();
                break;
            case WatcherState.CloseToPlayer:
                CloseToPlayerBehavior();
                break;
            case WatcherState.KillPlayer:
                KillPlayerBehavior();
                break;
        }
    }

    private void IdleBehavior()
    {
        if (player == null) return;

        agent.SetDestination(player.position);

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= detectionDistance)
        {
            currentState = WatcherState.CloseToPlayer;
        }
    }

    private void CloseToPlayerBehavior()
    {
        if (player == null) return;

        agent.SetDestination(player.position);

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= killDistance)
        {
            closeTimer += Time.deltaTime;
            if (closeTimer >= timeToKill)
            {
                currentState = WatcherState.KillPlayer;
            }
        }
        else
        {
            closeTimer = 0f; // Reset if player escapes
        }
    }

    private void KillPlayerBehavior()
    {
        Debug.Log("Player Killed by Watcher");
        FindObjectOfType<UiManager2>().ShowGameLostPanel();
        Destroy(this.gameObject); // Watcher disappears after kill
    }
}
