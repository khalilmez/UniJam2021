using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Choice", menuName = "Choice", order = 1)]
public class Choice : ScriptableObject
{
	public string text;
	public Dialogue conclusion;
	public int suspicion;
	public string hint;
	public bool win;
}
