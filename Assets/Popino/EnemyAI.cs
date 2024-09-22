using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
	NavMeshAgent _nm;
	Animator _anim;
	public Transform _player;
	float _distanceFollow = 20;
	float _distanceAttk = 5;
	bool _dead = false;
	public float dist;


	public enum AIState
	{
		idle, chasing, attack, dead
	};
	public AIState _stateMachine = AIState.idle;

	void Start()
	{
		_nm = gameObject.GetComponent<NavMeshAgent>();
		_anim = gameObject.GetComponent<Animator>();
		StartCoroutine(Think());
	}

	void Update()
	{

	}

	public IEnumerator Think()
	{
		while (true)
		{
			dist = Vector3.Distance(transform.position, _player.position);
			
			switch (_stateMachine)
			{
				case AIState.idle:
					if (dist < 45 && !_dead)
					{
						transform.LookAt(_player.position);
					}
					if (dist < _distanceFollow && !_dead)
					{
						_stateMachine = AIState.chasing;
						_anim.SetBool("Chasing", true);
						_nm.SetDestination(_player.position);
					}
					break;
				case AIState.chasing:
					if (dist < _distanceAttk && !_dead)
					{
						_stateMachine = AIState.attack;
						_anim.SetBool("Attack", true);
						_nm.SetDestination(transform.position);
					}
					else if (dist > _distanceFollow && !_dead)
					{
						_stateMachine = AIState.idle;
						_anim.SetBool("Chasing", false);
						_nm.SetDestination(transform.position);
					}
					else
					{
						_nm.SetDestination(_player.position);
					}
					break;
				case AIState.attack:

					break;
				case AIState.dead:

					break;
			}
			yield return new WaitForSeconds(0.2f);
		}
	}
}
