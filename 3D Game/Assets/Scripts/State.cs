using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class State : MonoBehaviour
{
    public Enemy enemy;
    public NavMeshAgent agent;
    public Transform player;
    public abstract State RunCurrentState();
}
