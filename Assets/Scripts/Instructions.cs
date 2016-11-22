using UnityEngine;
using System.Collections;

public class Instructions : MonoBehaviour {
	
	//Properties

	private int count = 0;

	[SerializeField]
	private PlayerController player;
	[SerializeField]
	private GameObject filter;
	
	[Header("Instructions images")]

	[SerializeField]
	private GameObject[] firstInstructionsImages = new GameObject[2];
	[SerializeField]
	private GameObject[] staminaAndFoodInstructionsImages = new GameObject[3];
	[SerializeField]
	private GameObject[] keysInstructionsImages = new GameObject[2];
	[SerializeField]
	private GameObject foodInstructionsImage;
	[SerializeField]
	private GameObject torchesInstructionsImage;
	[SerializeField]
	private GameObject statuesInstructionsImage;
	
	[HideInInspector]
	public bool firstInstructions;
	[HideInInspector]
	public bool staminaAndFoodInstructions;
	[HideInInspector]
	public bool keysInstructions;
	[HideInInspector]
	public bool foodInstructions;
	[HideInInspector]
	public bool torchesInstructions;
	[HideInInspector]
	public bool statuesInstructions;
	
	//Unity functions

	void Awake()
	{
		player = GetComponent<PlayerController>();
	}
	
	void Start()
	{
		filter.SetActive(false);
		
		ActiveInstructions(firstInstructionsImages,false);
		ActiveInstructions(staminaAndFoodInstructionsImages,false);
		ActiveInstructions(keysInstructionsImages,false);
		foodInstructionsImage.SetActive(false);
		torchesInstructionsImage.SetActive(false);
		statuesInstructionsImage.SetActive(false);
	}

	void Update()
	{
		Debug.Log(count);
		//Debug.Log(firstInstructionsImages.Length);
		//Debug.Log(staminaAndFoodInstructionsImages.Length);
		//Debug.Log(keysInstructionsImages.Length);

		if (Input.anyKeyDown)
		{
			if (firstInstructionsImages[count].activeInHierarchy)
			{
				if (count < firstInstructionsImages.Length-1)
				{
					firstInstructionsImages[count].SetActive(false);
					count++;
					firstInstructionsImages[count].SetActive(true);
				}
				else
				{
					filter.SetActive(false);
					firstInstructionsImages[count].SetActive(false);
					count = 0;
				}
			}

			if (staminaAndFoodInstructionsImages[count].activeInHierarchy)
			{
				if (count < staminaAndFoodInstructionsImages.Length-1)
				{
					staminaAndFoodInstructionsImages[count].SetActive(false);
					count++;
					staminaAndFoodInstructionsImages[count].SetActive(true);
				}
				else
				{
					filter.SetActive(false);
					staminaAndFoodInstructionsImages[count].SetActive(false);
					count = 0;
				}
			}

			if (keysInstructionsImages[count].activeInHierarchy)
			{
				if (count < keysInstructionsImages.Length-1)
				{
					keysInstructionsImages[count].SetActive(false);
					count++;
					keysInstructionsImages[count].SetActive(true);
				}
				else
				{
					filter.SetActive(false);
					keysInstructionsImages[count].SetActive(false);
					count = 0;
				}
			}

			if (foodInstructionsImage.activeInHierarchy)
			{
				filter.SetActive(false);
				foodInstructionsImage.SetActive(false);
			}

			if (torchesInstructionsImage.activeInHierarchy)
			{
				filter.SetActive(false);
				torchesInstructionsImage.SetActive(false);
			}

			if (statuesInstructionsImage.activeInHierarchy)
			{
				filter.SetActive(false);
				statuesInstructionsImage.SetActive(false);
			}
		}
	}
	
	//Class functions

	private void ActiveInstructions(GameObject[] instructions, bool state)
	{
		foreach(GameObject instruction in instructions)
		{
			instruction.SetActive(state);
		}
	}
	
	public void FirstInstructions()
	{
		filter.SetActive(true);
		firstInstructionsImages[0].SetActive(true);
		count++;
		firstInstructions = true;
	}

	public void StaminaAndFood()
	{
		filter.SetActive(true);
		staminaAndFoodInstructionsImages[0].SetActive(true);
		count++;
		staminaAndFoodInstructions = true;
	}

	public void Keys()
	{
		filter.SetActive(true);
		keysInstructionsImages[0].SetActive(true);
		count++;
		keysInstructions = true;
	}

	public void Food()
	{
		filter.SetActive(true);
		foodInstructionsImage.SetActive(true);
		foodInstructions = true;
	}

	public void Torches()
	{
		filter.SetActive(true);
		torchesInstructionsImage.SetActive(true);
		torchesInstructions = true;
	}

	public void Statues()
	{
		filter.SetActive(true);
		statuesInstructionsImage.SetActive(true);
		statuesInstructions = true;
	}
}