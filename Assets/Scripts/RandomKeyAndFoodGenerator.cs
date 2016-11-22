using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RandomKeyAndFoodGenerator : MonoBehaviour {

	//Singleton

	private static RandomKeyAndFoodGenerator instance;
	public static RandomKeyAndFoodGenerator Instance
	{
		get
		{
			return instance;
		}
	}
	
	//Properties

	[SerializeField]
	private int numberOfKeys;
	[SerializeField]
	private int numberOfFood;
	[SerializeField]
	private int xLimit;
	[SerializeField]
	private int zLimit;
	
	[Header("Prefabs")]
	
	[SerializeField]
	private GameObject foodPrefab;
	[SerializeField]
	private GameObject keyPrefab;

	private List<GameObject> keys = new List<GameObject>();
	private List<GameObject> food = new List<GameObject>();

	//Unity functions

	void Awake()
	{
		if (instance!=null)
		{
			Destroy(gameObject);
		}
		else
		{
			instance = this;
		}
	}

	void Start()
	{
		PrepareKeys();
		PrepareFood();
	}

	//Class functions

	private void PrepareKeys()
	{
		for(int i=0; i<numberOfKeys; i++)
		{
			CreateKey();
		}
	}

	private void PrepareFood()
	{
		for(int i=0; i<numberOfFood; i++)
		{
			CreateFood();
		}
	}

	private void CreateKey()
	{
		GameObject key = Instantiate( keyPrefab,
			
			new Vector3(
				Random.Range(-xLimit,xLimit),
				keyPrefab.transform.position.y,
				Random.Range(-zLimit,zLimit)),
			
			keyPrefab.transform.rotation) as GameObject;

		keys.Add(key);
	}

	private void CreateFood()
	{
		GameObject food = Instantiate( foodPrefab,
			
			new Vector3(
				Random.Range(-xLimit,xLimit),
				foodPrefab.transform.position.y,
				Random.Range(-zLimit,zLimit)),
			
			foodPrefab.transform.rotation) as GameObject;

		this.food.Add(food);
	}
}