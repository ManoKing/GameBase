using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;


public class EasyTouthController : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{

	Vector2 orgionPos;
	float radious = 100;
    Transform targetObj;
	Vector3 OldPosition;
    float distance;
	FSMManager fsmManger;

	private void Start()
	{
        targetObj = GameObject.FindWithTag("Player").transform;
		fsmManger = new FSMManager((byte)AnimalState.Max);
		Animator ani = targetObj.GetComponent<Animator>();
		PlayerIdle tmpIdle = new PlayerIdle(ani);
		fsmManger.AddState(tmpIdle);
		PlayerAttack tmpAttack = new PlayerAttack(ani, ChangeState);
		fsmManger.AddState(tmpAttack);
		PlayerWalk tmpWalk = new PlayerWalk(ani);
		fsmManger.AddState(tmpWalk);
		PlayerJump tmpJump = new PlayerJump(ani);
		fsmManger.AddState(tmpJump);

		orgionPos = transform.position;
		OldPosition = transform.position;

	}

	public void ChangeState(byte index)
	{
		fsmManger.ChangeState(index);
	}

	public void OnDrag(PointerEventData eventData)
	{

		Vector2 deltaPos = eventData.position - orgionPos;
	    distance = Vector2.Distance(eventData.position, orgionPos);

		if (distance < radious)
		{

			transform.position = eventData.position;
		}
		else
		{

			transform.position = orgionPos + deltaPos.normalized * radious;
		}
        targetObj.LookAt(new Vector3(deltaPos.x,0,deltaPos.y));
		if (distance > 95f)
		{
			fsmManger.ChangeState((byte)AnimalState.Attack);
		}
		else
		{

			fsmManger.ChangeState((byte)AnimalState.Walk);
		}

	}

	public void OnEndDrag(PointerEventData eventData)
	{
		transform.position = OldPosition;
		fsmManger.ChangeState((byte)AnimalState.Idle);

	}
	public void OnBeginDrag(PointerEventData eventData)
	{
        



	}

	private void Update()
	{
		if (transform.position != OldPosition)
		{
			if (distance > 95f)
            {
				targetObj.Translate(transform.forward * Time.deltaTime * 5f);
			}
			else
			{

				targetObj.Translate(transform.forward * Time.deltaTime * 2f);
			}

		}

		if (Input.GetKeyDown(KeyCode.Space))
		{
			fsmManger.ChangeState((byte)AnimalState.Jump);
		}
		if (Input.GetKeyDown(KeyCode.Q))
		{
			fsmManger.ChangeState((byte)AnimalState.Attack);
		}
		fsmManger.Update();
	}
}
