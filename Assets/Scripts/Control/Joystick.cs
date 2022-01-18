using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class Joystick : MonoBehaviour, IController
{

	public IController.OnMove onMove { get; set; }
	public IController.OnStop onStop { get; set; }
	public IController.OnMoveFixed onMoveFixed { get; set; }

	[SerializeField] private float maxDistanceDrag;
	[SerializeField] private RectTransform background;
	[SerializeField] private RectTransform stick;
	private Vector2 startMousePosition;
	private SimpleMouseControl simpleMouseControl;
	private bool isActive = false;

	private void Awake()
	{
		simpleMouseControl = new SimpleMouseControl();
		simpleMouseControl.Enable();
		simpleMouseControl.Game.Down.performed += StartDrag;
		simpleMouseControl.Game.Down.canceled += EndDrag;
	}
	private void StartDrag(InputAction.CallbackContext contex)
	{
		startMousePosition = simpleMouseControl.Game.Position.ReadValue<Vector2>();
		gameObject.SetActive(true);
		background.gameObject.SetActive(true);
		stick.gameObject.SetActive(true);
		isActive = true;
		background.anchoredPosition = startMousePosition;
		stick.anchoredPosition = startMousePosition;
	}
	private void Update()
	{
		if (onMove == null) return;
		BeingDrag((Vector2 v) => onMove.Invoke(v));
	}
	private void FixedUpdate()
	{
		if (onMoveFixed == null) return;
		BeingDrag((Vector2 v) => onMoveFixed.Invoke(v));
	}

	private void BeingDrag(Action<Vector2> onMoveAction)
	{
		if (!isActive) return;
		Vector2 currentMousePosition = simpleMouseControl.Game.Position.ReadValue<Vector2>();
		Vector2 direction = currentMousePosition - startMousePosition;
		if (direction.magnitude > maxDistanceDrag)
		{
			direction = direction.normalized * maxDistanceDrag;
		}
		stick.anchoredPosition = startMousePosition + direction;
		onMoveAction?.Invoke(direction / maxDistanceDrag);
	}

	private void EndDrag(InputAction.CallbackContext contex)
	{
		gameObject.SetActive(false);
		background.gameObject.SetActive(false);
		stick.gameObject.SetActive(false);
		isActive = false;
		onStop?.Invoke();
	}
	private void OnDestroy()
	{
		simpleMouseControl.Disable();
		simpleMouseControl.Game.Down.performed -= StartDrag;
		simpleMouseControl.Game.Down.canceled -= EndDrag;
	}
}
