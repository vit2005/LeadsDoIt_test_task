using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadController : MonoBehaviour
{

    public float speed;
    [SerializeField] List<Transform> roads = new List<Transform>();
    [SerializeField] Transform initialRoad;
    private readonly Vector3 shift = new Vector3 (0, 8192, 0);

    public void Init()
    {

    }

    private void Update()
    {
        transform.position -= Vector3.up * speed * Time.deltaTime;
        foreach (Transform road in roads )
        {
            if (road.position.y < 0) road.position += shift;
        }
    }
}
