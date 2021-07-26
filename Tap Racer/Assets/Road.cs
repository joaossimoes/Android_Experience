using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    LineRenderer laneLr;
    LineRenderer pavementLr;
    [SerializeField] Circuit circuit;

    // Start is called before the first frame update
    void Start()
    {
        laneLr = GetComponent<LineRenderer>();
        pavementLr = transform.GetChild(0).GetComponent<LineRenderer>();

        DrawCircuit();
    }

    void DrawCircuit()
    {
        List<GameObject> checkpoints = circuit.checkpoints;

        if (checkpoints.Count < 2)
        {
            Debug.LogWarning("Warning. It\'s not possible to draw the circuit with the current amount of checkpoints.");
            return;
        }

        List<Vector3> cpPositions = new List<Vector3>();

        for (int i = 0; i < checkpoints.Count; i++)
        {
            cpPositions.Add(checkpoints[i].transform.position);
            Debug.Log(cpPositions);
        }
        cpPositions.Add(checkpoints[0].transform.position);

        laneLr.positionCount = checkpoints.Count + 1;
        laneLr.SetPositions(cpPositions.ToArray());

        pavementLr.positionCount = laneLr.positionCount;
        pavementLr.SetPositions(cpPositions.ToArray());
        pavementLr.widthCurve = AnimationCurve.Constant(0f,0f,1.3f);
    }
}
