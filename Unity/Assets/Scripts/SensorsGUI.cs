﻿using UnityEngine;
using System.Collections;

public class SensorsGUI : MonoBehaviour {

	private bool showHelp;
	private bool showElectricityData;
	private bool showElectricityChartPhase1;
	private bool showElectricityChartPhase2;
	private bool showElectricityChartPhase3;
	private bool showDebugText;

	private string[] debugText;

	private float deltaTime = 0.0f;

	private bool showFPS;

	private ElectricityLogger electricityLogger;

	// Use this for initialization
	void Start () {
		showHelp = false;
		showElectricityData = false;
		showElectricityChartPhase1 = false;
		showElectricityChartPhase2 = false;
		showElectricityChartPhase3 = false;
		showDebugText = false;
		debugText = new string[10];
		showFPS = false;
		deltaTime = 0.0f;

		electricityLogger = GetComponent<ElectricityLogger> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.LeftControl) || Input.GetKeyDown (KeyCode.RightControl)) {
			showHelp = !showHelp;
		}
		if (showHelp) {
			if (Input.GetKeyDown (KeyCode.B)) {
				showDebugText = !showDebugText;
			}
			if (Input.GetKeyDown (KeyCode.F)) {
				showFPS = !showFPS;
			}
			if (Input.GetKeyDown (KeyCode.R)) {
				electricityLogger.ShowElectricityData = !electricityLogger.ShowElectricityData;
			}
			if (Input.GetKeyDown (KeyCode.C)) {
				electricityLogger.ShowElectronicCharts = !electricityLogger.ShowElectronicCharts;
			}
		}
		deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
	}

	void OnGUI() {
		if (IsAllFalse ())
			ShowSimpleGUI (2, 2, 80, 20);
		if (showHelp)
			ShowHelp (2, 24, 200, 200);
		if(showDebugText)
			ShowDebug (300, 30, 300, 300);
		float msec = deltaTime * 1000.0f;
		float fps = 1.0f / deltaTime;
		if (showFPS) {
			string text = string.Format ("{0:0.0} ms ({1:0.} fps)", msec, fps);
			GUI.Label (new Rect (400, 16, 128, 24), text);
		}
	}

	private bool IsAllFalse() {
		if (showElectricityData || showElectricityChartPhase1
			|| showElectricityChartPhase2 || showElectricityChartPhase3
			|| showDebugText || showHelp)
			return false;
		return true;
	}

	public void ShowSimpleGUI(int x, int y, int witdh, int heigth){
		GUI.Box (new Rect (x, y, witdh, heigth), "Menu 'Ctrl'");
	}

	public void ShowHelp(int x, int y, int witdh, int heigth) {
		GUI.Box (new Rect (x, y, witdh, heigth), "Help Box");
		GUI.Label (new Rect (x + 8, y + 16, witdh - 32, 24), "Press 'c' to show charts");
		GUI.Label (new Rect (x + 8, y + 32, witdh - 32, 24), "Press 'b' to show debug");
		GUI.Label (new Rect (x + 8, y + 48, witdh - 32, 24), "Press 'f' to show FPS");
		GUI.Label (new Rect (x + 8, y + 64, witdh - 32, 24), "Press 'r' to show data");
	}

	public void ShowDebug(int x, int y, int witdh, int heigth) {
		GUI.Box (new Rect (x, y, witdh, heigth), "Debug Box");
		int deltaY = 16;
		for (int i = debugText.Length-1; i > 0; i--) {
			GUI.Label (new Rect (x + 8, y + deltaY, witdh - 32, 24), debugText [i]);
			deltaY += 24;
		}
	}

	public void SetDebugText(int number, string text) {
		debugText [number] = text;
	}
		
}
