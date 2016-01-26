using UnityEngine;
using System.Collections;

public delegate void TargetAcquisitionEvent(PlayerTarget player, float distance, float errorDistance);

public class PlayerTracking : MonoBehaviour {

    public float AngularAcceleration;
    public LayerMask TrackingLevelLayers;
    public float DebugScale;

    public event TargetAcquisitionEvent targetAquired;

    // The player we are targeting.
    private PlayerTarget targetedPlayer;
    public PlayerTarget TargetedPlayer
    {
        get { return targetedPlayer; }
    }

    protected new Rigidbody rigidbody;

    protected void Start () {
        rigidbody = GetComponent<Rigidbody>();
        updateTargetedPlayerRountine = StartCoroutine(UpdateTargetedPlayerRountine());
        targetRotation = transform.rotation;

    }

    protected void OnDestroy()
    {
        StopCoroutine(updateTargetedPlayerRountine);
    }

    private Coroutine updateTargetedPlayerRountine;
    private IEnumerator UpdateTargetedPlayerRountine()
    {
        float interval = Random.Range(0.6f, 0.8f);
        while (true)
        {
            UpdateTargetedPlayer();
            yield return new WaitForSeconds(interval);
        }
    }

    private void UpdateTargetedPlayer()
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

            if (Physics.Raycast(transform.position, relativePlayerPosition, out hit, Mathf.Sqrt(playerDistance2), TrackingLevelLayers))
                continue;

            targetedPlayer = player;
            targetedPlayerDistance2 = playerDistance2;
        }
    }

    private Vector3 CalculateTargetPoint()
    {
        return targetedPlayer.transform.position;
    }

    private Quaternion CalculateTargetRotation( Vector3 targetPoint )
    {
        Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position, Vector3.up);
        return targetRotation;
    }

    private void UpdateAngularVelocity( Quaternion targetRotation )
    {
        // Calculate the target rotation relative to current rotation.
        Quaternion relativeTargetRotation = targetRotation * Quaternion.Inverse(transform.rotation);

        // Get the components of relative target rotation.
        Vector3 relativeTargetRotationAxis; float relativeTargetRotationAngle;
        relativeTargetRotation.ToAngleAxis(out relativeTargetRotationAngle, out relativeTargetRotationAxis);
        if( relativeTargetRotationAngle > 180f )
        {
            relativeTargetRotationAngle = 360f - relativeTargetRotationAngle;
            relativeTargetRotationAxis = -relativeTargetRotationAxis;
        }
        relativeTargetRotationAngle *= Mathf.PI / 180f;
        relativeTargetRotationAxis.Normalize();

        // Get the current angular velocity.
        Vector3 angularVelocity0 = rigidbody.angularVelocity;

        // Calculate the maximum angular velocity we want.
        float angularVelocityLimit = Mathf.Sqrt(2 * AngularAcceleration * relativeTargetRotationAngle);

        // Accelerate toward a point that is the relative angular position truncated to the velocity limit.
        Vector3 angularVelocityTarget = Mathf.Min(angularVelocityLimit, relativeTargetRotationAngle) * relativeTargetRotationAxis;
        Vector3 angularAccelerationStep = angularVelocityTarget - angularVelocity0;
        angularAccelerationStep *= Mathf.Min(1.0f, AngularAcceleration * Time.fixedDeltaTime / angularAccelerationStep.magnitude);

        // Apply acceleration.
        if( !float.IsNaN(angularAccelerationStep.x+angularAccelerationStep.y+angularAccelerationStep.z))
            rigidbody.angularVelocity = angularVelocity0 + angularAccelerationStep;

        if (DebugScale > 0)
        {
            Debug.DrawLine(transform.position + DebugScale * angularVelocityTarget, transform.position + DebugScale * relativeTargetRotationAngle * relativeTargetRotationAxis, Color.blue, 0.5f, false);
            Debug.DrawRay(transform.position, DebugScale * angularVelocityTarget, Color.green, 0.5f, false);
            Debug.DrawRay(transform.position, DebugScale * angularVelocity0, Color.red, 0.5f, false);
        }
        
    }

    private Vector3 targetPoint;
    private Quaternion targetRotation;
    protected void FixedUpdate()
    {
        if (targetedPlayer != null)
        {
            targetPoint = CalculateTargetPoint();
            targetRotation = CalculateTargetRotation(targetPoint);
        }

        UpdateAngularVelocity(targetRotation);
    }

    private void SignalTargetAcquisition()
    {
        if (targetAquired == null || targetedPlayer == null)
            return;

        Vector3 relativeTargetPoint = targetPoint - transform.position;
        Vector3 forward = transform.forward;
        float distance = Vector3.Dot(relativeTargetPoint, forward);
        if (distance < 0) return;

        float errorDistance = (distance * forward - relativeTargetPoint).magnitude;
        targetAquired(targetedPlayer, distance, errorDistance);
    }

    protected void Update()
    {
        SignalTargetAcquisition();

        if (DebugScale > 0)
        {
            Debug.DrawRay(transform.position, 2 * transform.forward, Color.yellow);
            if (Input.GetKeyDown(KeyCode.Keypad5))
                rigidbody.angularVelocity = AngularAcceleration * Mathf.PI * Random.Range(2, 3) * Random.onUnitSphere;
        }
    }

}
