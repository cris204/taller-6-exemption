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

	//void Awake()
	//{
		//player = GetComponent<PlayerController>();
	//}
	
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
		if (Input.anyKeyDown)
		{
			if (staminaAndFoodInstructionsImages[0].activeInHierarchy)
			{
				staminaAndFoodInstructionsImages[0].SetActive(false);
				staminaAndFoodInstructionsImages[1].SetActive(true);
			}
			else if (staminaAndFoodInstructionsImages[1].activeInHierarchy)
			{
				staminaAndFoodInstructionsImages[1].SetActive(false);
				staminaAndFoodInstructionsImages[2].SetActive(true);
			}
			else if (staminaAndFoodInstructionsImages[2].activeInHierarchy)
			{
				staminaAndFoodInstructionsImages[2].SetActive(false);
				filter.SetActive(false);
			}
				
			if (firstInstructionsImages[count].activeInHierarchy)
			{
				if (count == firstInstructionsImages.Length-1)
				{
					filter.SetActive(false);
					firstInstructionsImages[count].SetActive(false);
					count = 0;

					player.enabled = true;
				}
				else
				{
					firstInstructionsImages[count].SetActive(false);
					count++;
					firstInstructionsImages[count].SetActive(true);
				}
			}

			if (keysInstructionsImages[count].activeInHierarchy)
			{
				if (count == keysInstructionsImages.Length-1)
				{
					filter.SetActive(false);
					keysInstructionsImages[count].SetActive(false);
					count = 0;
				}
				else
				{
					keysInstructionsImages[count].SetActive(false);
					count++;
					keysInstructionsImages[count].SetActive(true);
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
		firstInstructions = true;
	}

	public void StaminaAndFood()
	{
		filter.SetActive(true);
		staminaAndFoodInstructionsImages[0].SetActive(true);
		staminaAndFoodInstructions = true;
	}

	public void Keys()
	{
		filter.SetActive(true);
		keysInstructionsImages[0].SetActive(true);
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