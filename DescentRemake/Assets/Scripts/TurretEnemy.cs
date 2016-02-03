using UnityEngine;
using System.Collections;

public class TurretEnemy : MonoBehaviour {

    public float shootingDistance = 10;
    public bool useMissiles = false;
    public bool useTripleShot = false;

    public float trackingVelocity;

    public float[] fireRates;

    private GameObject[] players;
    private GameObject nearestPlayer;
    private float nearestPlayerDistance = 1000;
    private FiringWeapons weapons;
    private HealthShield healthShield;


	// Use this for initialization
	void Start () {
        players = GameObject.FindGameObjectsWithTag("Player");
        weapons = GetComponent<FiringWeapons>();
        healthShield = GetComponent<HealthShield>();
	}
	
	// Update is called once per frame
	void Update () {

        //Destroy turret when health is 0
        if (healthShield.health == 0) {
            Destroy(this.gameObject);
        }

        foreach (GameObject player in players) {
            if (Vector3.Distance(this.transform.position, player.transform.position) < nearestPlayerDistance)
            {
                nearestPlayerDistance = Vector3.Distance(this.transform.position, player.transform.position);
                nearestPlayer = player;
            }
        }
        if (Vector3.Distance(nearestPlayer.transform.position, this.transform.position) < shootingDistance)
        {
            float distanceToPlayer = Vector3.Distance(nearestPlayer.transform.position, this.transform.position);
            Vector3 nearestVelocity = nearestPlayer.GetComponent<Rigidbody>().velocity;
            System.Random randomizer = new System.Random();
            int anticipationLimit = randomizer.Next(10, 40);
                                                  //Bullet speed + player speed
                                                  //Replace bullet speed with parameter when available
            float travelTimeX = distanceToPlayer / (Mathf.Abs(anticipationLimit) + nearestVelocity.x);
            float travelTimeY = distanceToPlayer / (Mathf.Abs(anticipationLimit) + nearestVelocity.y);
            float travelTimeZ = distanceToPlayer / (Mathf.Abs(anticipationLimit) + nearestVelocity.z);
            float futurePosX = travelTimeX * nearestVelocity.x;
            float futurePosY = travelTimeY * nearestVelocity.y;
            float futurePosZ = travelTimeZ * nearestVelocity.z;
            Vector3 nearestPosition = nearestPlayer.transform.position;
            Vector3 newPosition = new Vector3(nearestPosition.x + futurePosX, nearestPosition.y + futurePosY, nearestPosition.z + futurePosZ);

            //Quaternion lookRotation = Quaternion.LookRotation(nearestPlayer.transform.position - this.transform.position, Vector3.up);
            Quaternion lookRotation = Quaternion.LookRotation(newPosition - this.transform.position, Vector3.up);
            Quaternion relativeLookRotation = lookRotation * Quaternion.Inverse(transform.rotation);
            Vector3 relativeTargetRotationAxis; float relativeTargetRotationAngle;
            relativeLookRotation.ToAngleAxis(out relativeTargetRotationAngle, out relativeTargetRotationAxis);
            if (relativeTargetRotationAngle > 180f)
            {
                relativeTargetRotationAngle = 360f - relativeTargetRotationAngle;
                relativeTargetRotationAxis = -relativeTargetRotationAxis;
            }
            relativeTargetRotationAxis.Normalize();

            relativeTargetRotationAngle = Mathf.Min(relativeTargetRotationAngle, trackingVelocity * Time.deltaTime);
            transform.rotation = Quaternion.AngleAxis(relativeTargetRotationAngle, relativeTargetRotationAxis) * transform.rotation;

            if (!useTripleShot)
                weapons.InitiateStandardShoot(fireRates[0], "standard");
            else
                weapons.InitiateStandardShoot(fireRates[0], "triple");
            if (useMissiles)
                weapons.InitiateAlternativeShoot(fireRates[1]);
        }
        

	}
}
