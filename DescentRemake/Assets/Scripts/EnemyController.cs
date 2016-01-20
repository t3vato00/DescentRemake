using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

    public LayerMask mask;
    public float maxCastDistance;
    public static bool raycastHitThePlayer;
    public static float raycastDistance;
    public string[] raycastTags;
    // Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 10);
        //All collisions between enemy and world
        foreach (Collider collide in hitColliders)
        {
            for (int i = 0; i < raycastTags.Length; i++) {
                if (collide.tag.Equals(raycastTags[i])) {
                    if (Physics.Raycast(transform.position, collide.transform.position - transform.position, out hit, maxCastDistance, mask)) {
                        //Raycasts for all tags between enemy position and specific distance
                        //Use this to check for enemys line of sight
                        if (hit.transform.tag.Equals("Player"))
                        {
                            Debug.Log("found player");
                            raycastHitThePlayer = true;
                            raycastDistance = hit.distance;
                        }
                        else
                        {
                        }
                    }
                }
            }
        }
    }
}
