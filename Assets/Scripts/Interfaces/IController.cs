using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IController
{
	delegate void OnMove(Vector2 normolizedVector);
	OnMove onMove { get; set; } //fire every frame(in Update) when pointer is pressed
	delegate void OnMoveFixed(Vector2 normolizedVector);
	OnMoveFixed onMoveFixed { get; set; } //fire every FixedUpdate when pointer is pressed
	delegate void OnStop();
	OnStop onStop { get; set; }
}