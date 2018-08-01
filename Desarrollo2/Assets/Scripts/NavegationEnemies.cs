using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavegationEnemies : MonoBehaviour {

	private int currentWaypoint;
	private NavMeshAgent nma;

	public Transform[] targets;

	void Awake(){
		nma = GetComponent<NavMeshAgent> ();
		nma.destination = targets[currentWaypoint].position;
	}
	void Update(){
		if (!nma.pathPending && nma.remainingDistance <= nma.stoppingDistance) {
			currentWaypoint++;
			currentWaypoint %= targets.Length;
			nma.destination = targets [currentWaypoint].position;
		}
			
	}
}


