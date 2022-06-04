using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleAIController : MonoBehaviour
{
    [SerializeField] private float waitTime;
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private Transform spawnPos;
    [SerializeField] private GameObject simpleAIPrefab;
    [SerializeField] private GameObject ground;

    private Vector3 min, max;
    private List<SimpleAI> simpleAIlist = new List<SimpleAI>();
    private void Awake()
    {
        min = ground.GetComponent<Renderer>().bounds.min;
        max = ground.GetComponent<Renderer>().bounds.max;
        Spawn();
    }

    private void Spawn()
    {
        GameObject temp = Instantiate(simpleAIPrefab, GetRandomVector3(min, max), Quaternion.Euler(0, 0, 0), transform);
        SimpleAI simpleAI = temp.GetComponent<SimpleAI>();
        simpleAIlist.Add(simpleAI);
        simpleAI.onFinishedMove += InitNewMove;
        InitNewMove(simpleAI);
    }
    public void InitNewMove(SimpleAI AI)
    {
        AI.MoveProcess(GetRandomVector3(min, max), waitTime, speed, rotationSpeed);
    }

    private Vector3 GetRandomVector3(Vector3 min, Vector3 max)
    {
        Vector3 worldSpace = new Vector3(Random.Range(min.x, max.x), Random.Range(min.y, max.y), Random.Range(min.z, max.z));
        return worldSpace + new Vector3(0,1f,0);
    }


}
