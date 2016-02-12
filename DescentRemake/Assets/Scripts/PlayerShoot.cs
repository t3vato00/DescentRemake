using UnityEngine;
using System.Collections;

/*  Reads player's inputs and uses class "FiringWeapons" to initiate shooting and item usage.
    Needs inputs:
    "Fire1" to shoot bullets
    "Fire2" to shoot missiles
    "Item" to shoot flares*/

public class PlayerShoot : MonoBehaviour {

<<<<<<< HEAD
    private float firerate;
    private float missilerate;
    private float itemrate;
=======
    public int bulletCounter = 0;
    [SerializeField]
    private float FireRateForPrimaryFire;
    [SerializeField]
    private float FireRateForAltFire;
    [SerializeField]
    private float FireRateForItems;
>>>>>>> develop
    private float nextbullet;
    private float nextmissile;
    private float nextitem;

    //Firemode can be "standard" , "triple" & "auto"
    public string firemode;

    private FiringWeapons weapons;
    private UnityEngine.UI.Image bulletOvImage;
    private UnityEngine.UI.Image missileOvImage;
    private UnityEngine.UI.Image itemOvImage;

    // Use this for initialization
    void Start () {
        firerate = 0.2f;
        missilerate = 0.5f;
        itemrate = 1.0f;
        weapons = this.GetComponent<FiringWeapons>();
        bulletOvImage = GameObject.Find("BulletOverlay").GetComponent<UnityEngine.UI.Image>();
        missileOvImage = GameObject.Find("MissileOverlay").GetComponent<UnityEngine.UI.Image>();
        itemOvImage = GameObject.Find("ItemOverlay").GetComponent<UnityEngine.UI.Image>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            if (Time.time > nextbullet)
            {
<<<<<<< HEAD
                weapons.InitiateStandardShoot(firerate, firemode);
                nextbullet = Time.time + firerate;
=======
                weapons.InitiateStandardShoot(FireRateForPrimaryFire, firemode);
                nextbullet = Time.time + FireRateForPrimaryFire;
                bulletCounter++;
>>>>>>> develop
            }
        }else if (Input.GetButtonUp("Fire1") && firemode == "auto")
        {
            weapons.DisableAutofire();
        }
        else if (Input.GetButtonDown("Fire2"))
        {
            if (Time.time > nextmissile)
            {
                weapons.InitiateAlternativeShoot(missilerate);
                nextmissile = Time.time + missilerate;
            }
        }
        else if (Input.GetButtonDown("Item"))
        {
            if (Time.time > nextitem)
            {
                weapons.InitiateItemActivation(itemrate);
                nextitem = Time.time + itemrate;
            }
        }
        /*if(bulletOvImage.rectTransform.localScale.y > 0)
        {
            bulletOvImage.rectTransform.localScale = new Vector3(1, Mathf.Lerp(1, 0, firerate), 1);
        }*/
    }
}
