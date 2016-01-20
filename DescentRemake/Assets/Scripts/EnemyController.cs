using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

    public LayerMask mask;
    public float maxCastDistance;
    public static bool raycastHitThePlayer;
    public static bool raycastHitTheWall;
    public static float raycastDistance;
    public string[] tags;
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
            for (int i = 0; i < tags.Length; i++) {
                if (collide.tag.Equals(tags[i])) {
                    if (Physics.Raycast(transform.position, collide.transform.position - transform.position, out hit, maxCastDistance, mask)) {
                        //Raycasts for all tags between enemy position and specific distance
                        //Use this to check for enemys line of sight
                        if (hit.transform.tag.Equals("Player"))
                        {
                            raycastHitThePlayer = true;
                            raycastHitTheWall = false;
                            raycastDistance = hit.distance;
                        }
                        else if (hit.transform.tag.Equals("Wall"))
                        {
                            raycastHitThePlayer = false;
                            raycastHitTheWall = true;
                            raycastDistance = hit.distance;
                        }
                        else
                        {
                            raycastHitTheWall = false;
                            raycastHitThePlayer = false;
                        }
                    }
                }
            }
            /*
            if(collide.tag.Equals("Player") || collide.tag.Equals("Wall"))
            {
                if (Physics.Raycast(transform.position, collide.transform.position - transform.position, out hit, maxCastDistance, mask))
                {
                    if (hit.transform.tag.Equals("Player"))
                    {
                        raycastHitThePlayer = true;
                        raycastHitTheWall = false;
                        raycastDistance = hit.distance;
                    }
                    else if (hit.transform.tag.Equals("Wall"))
                    {
                        raycastHitThePlayer = false;
                        raycastHitTheWall = true;
                        raycastDistance = hit.distance;
                    }
                    else
                    {
                        raycastHitTheWall = false;
                        raycastHitThePlayer = false;
                    }
                }
                
            }
            */
        }
    }
}
