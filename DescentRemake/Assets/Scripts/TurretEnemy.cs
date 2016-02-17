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

    private GameObject instantiatedObj1;
    [SerializeField]
    private GameObject missilexplosion;


	// Use this for initialization
	void Start () {
        players = GameObject.FindGameObjectsWithTag("Player");
        weapons = GetComponent<FiringWeapons>();

	}
    bool notDestroying = false;
    void LateUpdate() {
        //Destroy turret when health is 0
        if (healthShield.health == 0 && !notDestroying)
        {
            notDestroying = true;
            Destroy(this.gameObject, 0.5f);
            missilexplosion.transform.localScale = new Vector3(3f, 3f, 3f);
            instantiatedObj1 = (GameObject)Instantiate(missilexplosion, this.transform.position, this.transform.rotation);

            Destroy(instantiatedObj1, 1.8f);
        }
    }
	
	// Update is called once per frame
	void Update () {
<<<<<<< HEAD
=======



>>>>>>> 523530014a93d5e0a0e7fa04604a9d7656103086
        foreach (GameObject player in players) {
            if (Vector3.Distance(this.transform.position, player.transform.position) < nearestPlayerDistance)
            {
                nearestPlayerDistance = Vector3.Distance(this.transform.position, player.transform.position);
                nearestPlayer = player;
            }
        }
        if (Vector3.Distance(nearestPlayer.transform.position, this.transform.position) < shootingDistance)
        {
            Quaternion lookRotation = Quaternion.LookRotation(nearestPlayer.transform.position - this.transform.position, Vector3.up);
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
