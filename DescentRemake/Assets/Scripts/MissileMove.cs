using UnityEngine;
using System.Collections;

public class MissileMove : MonoBehaviour
{
    private Vector3 direction;
    [SerializeField]
    private GameObject missilexplosion;
    private float speed;
    private float radius = 15.0f;
    private float power = 100.0f;
    private GameObject instantiatedObj;

    void Start()
    {
        direction = this.transform.forward;
        speed = 1f;
        GameObject.Destroy(this.gameObject, 10f);
    }

    void Update()
    {
        if (speed < 50)
        {
            speed+=2.5f;
        }
        this.GetComponent<Rigidbody>().AddForce(direction * speed);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag != "Bullet" && col.gameObject.tag != "Player")
        {
            Vector3 explosionPos = this.transform.position;
            Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
            foreach (Collider hit in colliders)
            {
                Rigidbody rb = hit.GetComponent<Rigidbody>();

                if (rb != null)
                    rb.AddExplosionForce(power, explosionPos, radius, 3.0f, ForceMode.Force);
            }
            instantiatedObj = (GameObject) Instantiate(missilexplosion, this.transform.position, this.transform.rotation);
            Destroy(this.gameObject);

            Destroy(instantiatedObj, 1.8f);
        }
    }
}
