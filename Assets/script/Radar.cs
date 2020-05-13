using System;
﻿using System.Collections;
using System.Collections.Generic;
//using System.IO.Ports;
using System.Threading;
using UnityEngine;

public class Radar : MonoBehaviour
{
	//private SerialPort _serialPort;
	private Transform sweepTransform;
	private float rotationSpeed;
	private float radarDistance;

	private void Awake(){
		sweepTransform = transform.Find("Sweep");
		rotationSpeed = 180f;
		radarDistance = 150f;	
		/*_serialPort = new SerialPort();
		_serialPort.PortName = "COM4";
		_serialPort.BaudRate = 9600;
		_serialPort.Open();*/
	}

	private void Update(){
		//string a = _serialPort.ReadExisting();
                //Console.WriteLine(a);
                //Thread.Sleep(200);

		sweepTransform.eulerAngles -= new Vector3(0,0, rotationSpeed * Time.deltaTime);
		RaycastHit2D raycastHit2D = Physics2D.Raycast(transform.position, GetVectorFromAngle(sweepTransform.eulerAngles.z), radarDistance);

		if(raycastHit2D.collider != null){
		
		}
	}

	private Vector3 GetVectorFromAngle(float angle){
		// angle = 0 -> 360
		float angleRad = angle * ( Mathf.PI/180f);
		return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad), 1);
	}
}
