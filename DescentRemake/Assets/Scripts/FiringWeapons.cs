using UnityEngine;
using System.Collections;

public class FiringWeapons : MonoBehaviour {

    public GameObject bullet;
    public GameObject missile;
    public GameObject flare;
    public GameObject emp;
    public GameObject decoy;
    private GameObject instanceofcreatedprojectileleft;
    private GameObject instanceofcreatedprojectileright;
    private Transform bulletpointleft;
    private Transform bulletpointright;
    private Transform bulletpointupper;
    private Transform missilepoint;
    private Transform playerpoint;
    private Quaternion decoyrotationaddition;
    private Quaternion decoyrotation;
    private float nextfire;
    private float nextmissile;
    private float nextitem;
    private float firerate;
    private float missilerate;
    private float itemrate;
    private string firemode;
    private string itemname;
    private bool autofire;
    private bool isEnemy = false;

	public int hitCount;
	public int killCount;

    PhotonView photonView;

    


	// Use this for initialization
	void Start () {
        photonView = PhotonView.Get(this);


        missilepoint = this.transform.Find("MissilePoint").transform;
        bulletpointleft = this.transform.Find("BulletPointLeft").transform;
        bulletpointright = this.transform.Find("BulletPointRight").transform;
        bulletpointupper = this.transform.Find("BulletPointUpper").transform;
        playerpoint = this.transform;
        firemode = "standard";
        nextfire = 0f;
        nextmissile = 0f;
        nextitem = 0f;
        firerate = 0.2f;
        missilerate = 0.5f;
        itemrate = 1.0f;
        autofire = false;

        if(this.gameObject.tag == "Turret")
        {
            isEnemy = true;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (autofire && Time.time > nextfire)
        {
            Instantiate(bullet, bulletpointleft.position, bulletpointleft.rotation);
            Instantiate(bullet, bulletpointright.position, bulletpointright.rotation);
            nextfire = Time.time + firerate;
        }
		if (bullet != null) {
			bullet.GetComponent<BulletMove> ().firedPlayer = gameObject;
			missile.GetComponent<MissileMove> ().firedPlayer = gameObject;
		}



    }


	public void addHit() {
		hitCount++;
	}

	public void addKill() {
		killCount++;
		Debug.Log ("Adding kill");
		GetComponent<ChatManager> ().killStreak (GetComponent<ChatManager> ().username, killCount);
		GetComponent<NetworkCharacterMovement> ().sendKill ();
	}

    public void InitiateStandardShoot(float rateForFire, string modeForFire)
    {
        firerate = rateForFire;
        firemode = modeForFire;
        StandardShoot();
    }

    private void StandardShoot()
    {
        if (Time.time > nextfire) {
            if (firemode == "standard") {
                //instanceofcreatedprojectileleft = Instantiate(bullet, bulletpointleft.position, bulletpointleft.rotation) as GameObject;
                //instanceofcreatedprojectileright = Instantiate(bullet, bulletpointright.position, bulletpointright.rotation) as GameObject;

                photonView.RPC("BulletFX", PhotonTargets.All, bulletpointright.position, bulletpointright.rotation);
                photonView.RPC("BulletFX", PhotonTargets.All, bulletpointleft.position, bulletpointleft.rotation);
                
                if (isEnemy)
                {
                    instanceofcreatedprojectileleft.GetComponent<BulletMove>().EnemyShotThisProjectile();
                    instanceofcreatedprojectileright.GetComponent<BulletMove>().EnemyShotThisProjectile();
                }
                nextfire = Time.time + firerate;
            }
            else if (firemode == "triple")
            {
                Instantiate(bullet, bulletpointleft.position, bulletpointleft.rotation);
                Instantiate(bullet, bulletpointright.position, bulletpointright.rotation);
                Instantiate(bullet, bulletpointupper.position, bulletpointupper.rotation);
                nextfire = Time.time + firerate;
            }
            else if (firemode == "auto")
            {
                autofire = true;
            }

        }
    }

    public void DisableAutofire()
    {
        autofire = false;
    }

    public void InitiateAlternativeShoot(float rateForMissile)
    {
        missilerate = rateForMissile;
        AlternativeShoot();
    }

    public void InitiateItemActivation(string nameForItem, float rateForItem)
    {
        itemrate = rateForItem;
        itemname = nameForItem;
        ItemActivate();
    }

    private void AlternativeShoot()
    {
        if (Time.time > nextmissile)
        {

            photonView.RPC("MissileFX", PhotonTargets.All, missilepoint.position, missilepoint.rotation);
            nextmissile = Time.time + missilerate;
        }
    }

    private void ItemActivate()
    {
        if (Time.time > nextitem && itemname == "flare")
        {
            Instantiate(flare, missilepoint.position, missilepoint.rotation);
            nextitem = Time.time + itemrate;
        }else if (Time.time > nextitem && itemname == "emp")
        {
            Instantiate(emp, playerpoint.position, playerpoint.rotation);
            nextitem = Time.time + itemrate;
        }
        else if (Time.time > nextitem && itemname == "decoy")
        {
            decoyrotation = missilepoint.rotation;
            decoyrotation *= Quaternion.Euler(90, 0, 0);
            Instantiate(decoy, missilepoint.position, decoyrotation);
            nextitem = Time.time + itemrate;
        }
    }
    [PunRPC]
    void BulletFX(Vector3 bulletPointPosition, Quaternion bulletPointRotation)
    {
        Debug.Log(bulletPointPosition);
        Instantiate(bullet, bulletPointPosition, bulletPointRotation);


    }

    [PunRPC]
    void MissileFX(Vector3 MissilePointPosition, Quaternion MissilePointRotation)
    {
        Debug.Log(MissilePointPosition);
        Instantiate(missile, MissilePointPosition, MissilePointRotation);


    }
}
