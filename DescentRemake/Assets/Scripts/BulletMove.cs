using UnityEngine;
using System.Collections;

public class BulletMove : MonoBehaviour {

    private Vector3 direction;
    [SerializeField]
    private GameObject bullethiteffect;
    private float speed;
    private float radius = 0.35f;
    private float power = 50.0f;

    // Use this for initialization
    void Start () {
        direction = this.transform.forward;
        speed = 1000f;
        this.GetComponent<Rigidbody>().AddForce(direction * speed);
        GameObject.Destroy(this.gameObject, 5f);
    }
	
	// Update is called once per frame
	void Update () {
        this.transform.Rotate(0f, 0f, 10f,Space.Self);
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag != "Bullet" && col.gameObject.tag != "Player") {
        Vector3 explosionPos = this.transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
                rb.AddExplosionForce(power, explosionPos, radius, 3.0f, ForceMode.Force);
        }
            Instantiate(bullethiteffect, this.transform.position, this.transform.rotation);
            Destroy(this.gameObject);
    }
    }
}
