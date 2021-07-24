using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Curve : MonoBehaviour
{
    [SerializeField] [Range(0,100)] int pointCount = 1;
    [SerializeField] [Range(0, 100)] float length = 1f;
    [SerializeField] [Range(0, 8*Mathf.PI)] float angle = 0f;

    [Header("Gizmos")]
    [SerializeField] float pointRadius = 0.1f;
    [SerializeField] bool spiral = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnDrawGizmos()
    {
        if (pointCount > 1)
        {
            List<Vector2> curvePoints = new List<Vector2>();

            List<Vector2> distortedCurvePoints = new List<Vector2>();

            Gizmos.color = Color.blue;
            Vector2 localPosition = transform.localPosition;

            // distance between points
            float increment = length / (pointCount - 1);
            // angle between points
            float angleIncrement = angle / (pointCount - 1);

            for (int i = 0; i < pointCount; i++)
            {

                Vector2 currentPoint = localPosition + Vector2.right * increment * i;
                curvePoints.Add(currentPoint);

                if (spiral) currentPoint = localPosition;

                distortedCurvePoints.Add(new Vector2(currentPoint.x + Mathf.Cos(angleIncrement*i) * increment * i, currentPoint.y + Mathf.Sin(angleIncrement*i) * increment * i));
                Gizmos.DrawWireSphere(distortedCurvePoints[i], pointRadius);

                if (i > 0)
                {
                    // Draws line between current checkpoint and the next
                    Gizmos.DrawLine(distortedCurvePoints[i-1], distortedCurvePoints[i]);
                }
            }
        }
    }

}
