using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

    public LayerMask mask;
    public float maxCastDistance;
    public static bool raycastHitThePlayer;
    public static bool raycastHitTheWall;
    public static float raycastDistance;
    // Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 10);
        foreach(Collider collide in hitColliders)
        {
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
        }
    }
}
