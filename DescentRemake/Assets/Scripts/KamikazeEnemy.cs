using UnityEngine;
using System.Collections;

public class KamikazeEnemy : MonoBehaviour {

    public float rotationSpeed;
    public float movementSpeed;


    void Start()
    {
    }

    void FixedUpdate()
    {
        if (EnemyController.raycastHitThePlayer)
            MoveEnemy();
    }

    void MoveEnemy()
    {
        Transform player = GameObject.FindGameObjectWithTag("Player").transform;
        Vector3 moveDirection = player.position - transform.position;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(player.position - transform.position), rotationSpeed * Time.fixedDeltaTime);
        transform.position += transform.forward * movementSpeed * Time.fixedDeltaTime;
    }
    
}
