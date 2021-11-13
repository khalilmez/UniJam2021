using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue", menuName = "Quest", order = 1)]
public class Dialogue : ScriptableObject
{
	public string title;
	public string description;
	public List<Choice> choices = new List<Choice>();
}
