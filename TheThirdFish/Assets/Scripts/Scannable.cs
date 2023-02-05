using UnityEngine;
using System.Collections;

public class Scannable : MonoBehaviour
{
	public GameObject ping;

	public void Ping()
	{
		ping.SetActive(true);
	}
}
