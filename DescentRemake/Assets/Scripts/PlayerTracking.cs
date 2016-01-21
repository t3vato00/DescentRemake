using UnityEngine;
using System.Collections;

public abstract class PlayerTracking : MonoBehaviour {

    public float angularAcceleration;

    protected new Rigidbody rigidbody;

    // Use this for initialization
    protected void Start () {
        rigidbody = GetComponent<Rigidbody>();
    }

    protected Quaternion CalculateTargetRotation( Quaternion currentRoation, Vector3 targetPoint )
    {
        Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position, Vector3.up);
        return targetRotation;
    }

    protected void UpdateAngularVelocity( Quaternion targetRotation )
    {
        // Calculate the target rotation relative to current rotation.
        Quaternion relativeTargetRotation = targetRotation * Quaternion.Inverse(transform.rotation);

        // Get the components of relative target rotation.
        Vector3 relativeTargetRotationAxis; float relativeTargetRotationAngle;
        relativeTargetRotation.ToAngleAxis(out relativeTargetRotationAngle, out relativeTargetRotationAxis);

        // Get the components of current angular velocity.
        Vector3 angularVelocity0 = rigidbody.angularVelocity;
        float angularVelocityAngle0 = angularVelocity0.magnitude;
        Vector3 angularVelocityAxis0 = angularVelocity0 / angularVelocityAngle0;

        // Calculate the maximum angular velocity we want.
        float angularVelocityLimit = 0.95f * Mathf.Sqrt(2 * angularAcceleration * relativeTargetRotationAngle);

        // Accelerate toward a point that is the relative angular position truncated to the velocity limit.
        Vector3 angularVelocityTarget = Mathf.Min(angularVelocityLimit, relativeTargetRotationAngle) * relativeTargetRotationAxis;
        Vector3 angularAccelerationStep = angularVelocityTarget - angularVelocity0;
        angularAccelerationStep *= Mathf.Min(1.0f, angularAcceleration / angularAccelerationStep.magnitude);

        // Apply acceleration.
        rigidbody.angularVelocity += angularAccelerationStep;
    }
}
