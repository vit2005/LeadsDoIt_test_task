using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadController : MonoBehaviour
{

    public float speed;
    [SerializeField] List<Transform> roads = new List<Transform>();
    [SerializeField] Transform initialRoad;
    private readonly Vector3 shift = new Vector3 (0, 40, 0);

    public void Init()
    {

    }

    private void Update()
    {
        transform.position -= Vector3.up * SpeedController.speed * 0.01f * Time.deltaTime;
        foreach (Transform road in roads )
        {
            if (road.position.y < -10) road.position += shift;
        }
    }
}
