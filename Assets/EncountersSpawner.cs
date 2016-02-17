using UnityEngine;
using System.Collections;

public class EncountersSpawner : MonoBehaviour {

	public GameObject[] encounters;
	private float delay = 10f;
	private int lastIndex = -1;
	private int preLastIndex = -1;
	// Use this for initialization
	void Start () {
		Invoke("CreateEncounter", 1f);
	}
	
	// Update is called once per frame
	void CreateEncounter () {
	
		GameObject encountersObject = GameObject.Find("Encounters"); 
		if(!encountersObject) 
		{ 
			encountersObject = new GameObject("Encounters");  
		}
		int index = Mathf.RoundToInt(Random.value*(encounters.Length-1));
		while (lastIndex==index || preLastIndex==index)
		{
			if(index==encounters.Length-1)
			{
				index = 0;
			} else 
			{
				index++;
			}
		}
		//Debug.Log (lastEnc + " " + encounters[index].name + " " + lastEnc.IndexOf(encounters[index].name));
		GameObject encounter = Instantiate(encounters[index], new Vector3(20f+Random.Range(0f,10f),-9f,-5f),Quaternion.identity) as GameObject;
		encounter.transform.parent = encountersObject.transform;
		preLastIndex = lastIndex;
		lastIndex = index;
	

		float currentDelay = delay;
		if(encounter.GetComponent<EncounterMover>().delayAfterMe!=0)
		{
			currentDelay = encounter.GetComponent<EncounterMover>().delayAfterMe;
		}
		Invoke("CreateEncounter", currentDelay+Random.Range(0,15));
	}
}
