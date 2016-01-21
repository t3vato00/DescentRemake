using UnityEngine;
using System.Collections;

public class BasicPlayerTracking : PlayerTracking
{
    // The player we are targeting.
    private PlayerTarget targetedPlayer;

    public LayerMask staticPathFindingLayerMask;

    public PlayerTarget TargetedPlayer
    {
        get { return targetedPlayer; }
    }

    // Use this for initialization
    new void Start()
    {
        updateTargetedPlayerRountine = StartCoroutine(UpdateTargetedPlayerRountine());
        base.Start();
    }

    void OnDestroy()
    {
        StopCoroutine(updateTargetedPlayerRountine);
    }

    private Coroutine updateTargetedPlayerRountine;
    IEnumerator UpdateTargetedPlayerRountine()
    {
        float interval = Random.Range(0.6f, 0.8f);
        while (true)
        {
            UpdateTargetedPlayer();
            yield return new WaitForSeconds(interval);
        }
    }

    void UpdateTargetedPlayer()
    {
        RaycastHit hit;

        // Find nearest visible player.
        targetedPlayer = null;
        float targetedPlayerDistance2 = float.PositiveInfinity;
        foreach (PlayerTarget player in PlayerTarget.Players)
        {
            Vector3 relativePlayerPosition = player.transform.position - transform.position;
            float playerDistance2 = relativePlayerPosition.sqrMagnitude;

            if (playerDistance2 >= targetedPlayerDistance2)
                continue;

            if (Physics.Raycast(transform.position, relativePlayerPosition, out hit, Mathf.Sqrt(playerDistance2), staticPathFindingLayerMask))
                continue;

            targetedPlayer = player;
            targetedPlayerDistance2 = playerDistance2;
        }
    }

    void FixedUpdate()
    {
        if (targetedPlayer == null)
            return;

        Vector3 targetPoint = targetedPlayer.transform.position;

        UpdateAngularVelocity(CalculateTargetRotation(transform.rotation, targetPoint));
    }
}
