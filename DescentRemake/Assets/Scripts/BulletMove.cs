using UnityEngine;
using System.Collections;

public class BulletMove : MonoBehaviour {

    private Vector3 direction;
<<<<<<< HEAD
    private float speed;
=======
    [SerializeField]
    private GameObject bullethiteffect;
    private GameObject player;
    //Projectile's speed
    [SerializeField]
    private float speed = 1000f;
>>>>>>> develop
    private float radius = 0.35f;
    private float power = 50.0f;

    // Use this for initialization
    void Start () {
        direction = this.transform.forward;
<<<<<<< HEAD
        speed = 75f;
=======
        player = GameObject.FindGameObjectWithTag("Player");
        this.GetComponent<Rigidbody>().velocity = player.GetComponent<Rigidbody>().velocity;
        this.GetComponent<Rigidbody>().AddForce(direction * speed);
>>>>>>> develop
        GameObject.Destroy(this.gameObject, 5f);
    }
	
	// Update is called once per frame
	void Update () {
        this.GetComponent<Rigidbody>().AddForce(direction * speed);
        this.transform.Rotate(0f, 0f, 10f,Space.Self);
	}

    void OnTriggerEnter(Collider col)
    {
        Vector3 explosionPos = this.transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
                rb.AddExplosionForce(power, explosionPos, radius, 3.0f, ForceMode.Force);
        }
        Destroy(this.gameObject);
    }
}
