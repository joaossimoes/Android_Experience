using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    List<GameObject> checkpoints;
    Circuit circuit;
    Vector3 targetPos;
    int checkpointIndex;

    // Start is called before the first frame update
    void Start()
    {
        circuit = FindObjectOfType<Circuit>();
        checkpoints = circuit.GetCheckpoints();
        checkpointIndex = 0;
        transform.position = checkpoints[0].transform.position;
        targetPos = checkpoints[checkpointIndex + 1].transform.position;
        checkpointIndex++;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, 1f * Time.deltaTime);
        TargetPosition();
    }

    void TargetPosition()
    {
        if (Vector2.Distance(transform.position, targetPos) < Mathf.Epsilon)
        {
            checkpointIndex++;
            if (checkpointIndex > checkpoints.ToArray().Length - 1) {checkpointIndex = 0;}
            targetPos = checkpoints[checkpointIndex].transform.position;
        }

    }
}
