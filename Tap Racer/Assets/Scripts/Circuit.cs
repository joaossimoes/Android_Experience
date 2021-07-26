using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circuit : MonoBehaviour
{
    public List<GameObject> checkpoints;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public List<GameObject> GetCheckpoints()
    {
        return checkpoints;
    }

    // Draws lines between checkpoints in Editor mode ONLY
    void OnDrawGizmos()
    {
        // If the number of checkpoints is less than 2, it's not even worth it
        if (checkpoints.Count > 1)
        {
            Gizmos.color = Color.yellow;
            for (int i = 0; i < checkpoints.Count; i++)
            {
                // Draws line between current checkpoint and the next
                Gizmos.DrawLine(checkpoints[i].transform.position, checkpoints[i + 1 == checkpoints.Count ? 0 : i + 1].transform.position);
            }
        }
    }
}
