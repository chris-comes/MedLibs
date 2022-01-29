using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MicrophoneInputManager : MonoBehaviour
{
	AudioSource recording;
	Controls controls;

	private void Awake()
	{
		controls = new Controls();
	}

	private void OnEnable()
	{
		controls.Record.Record.started += QueRecording;
		controls.Record.Record.performed += StartRecording;
		controls.Record.Record.canceled += StopRecording;
		controls.Enable();
	}

	private void OnDisable()
	{
		controls.Record.Record.started -= QueRecording;
		controls.Record.Record.performed -= StartRecording;
		controls.Record.Record.canceled -= StopRecording;
		controls.Disable();
	}

	private void Start()
	{
		foreach (var device in Microphone.devices)
		{
			Debug.Log("device: " + device);
		}
	}

	//Called when button is first pressed down, but before the recording actually starts
	private void QueRecording(InputAction.CallbackContext ctx)
	{
		Debug.Log("space is qued");
	}

	//Not called immediately on button press
	private void StartRecording(InputAction.CallbackContext ctx)
	{
		Debug.Log("space is starting");
	}

	//Called on button release
	private void StopRecording(InputAction.CallbackContext ctx)
	{
		Debug.Log("space has ended");
	}
}
