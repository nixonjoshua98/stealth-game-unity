using System;
using UnityEngine;

using Pathfinding;
using UnityEngine.Experimental.Rendering.Universal;

public class EnemyController : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] Animator anim;
    [SerializeField] SpriteRenderer sr;
    [SerializeField] Light2D enemyLight;

    [SerializeField] AILerp ai;

    GameObject player;

    int currentTarget;

    [SerializeField] Transform[] targets;

    float viewDistance = 5.0f;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
      
        EventManager.OnLightToggle.AddListener(OnLightToggle);
    }

    void Update()
    {
        Vector2 targetPosition = Vector2.zero;

        if (IsPlayerInRange())
        {
            ai.destination = targetPosition = player.transform.position;
        }
        else
        {
            if (ai && ai.reachedDestination)
            {
                currentTarget++;

                if (currentTarget >= targets.Length)
                {
                    currentTarget = 0;
                }
            }

            if (ai && targets != null)
            {
                ai.destination = targetPosition = targets[currentTarget].position;
            }        
        }

        Vector2 direction = (targetPosition - new Vector2(transform.position.x, transform.position.y)).normalized;

        sr.flipX = direction.x > 0.0f;

        anim.SetFloat("MoveX", direction.x);
        anim.SetFloat("MoveY", direction.y);

    }

    bool IsPlayerInRange()
    {
        return Vector2.Distance(transform.position, player.transform.position) <= viewDistance;
    }

    void OnLightToggle(bool enabled)
    {
        enemyLight.enabled = !enabled;

        viewDistance = enabled ? 5.0f : 1.0f;

        ai.speed = PlayerController.MOVE_SPEED * (enabled ? 1.10f : 0.65f);
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            LevelManager.RestartLevel();
        }
    }
}
