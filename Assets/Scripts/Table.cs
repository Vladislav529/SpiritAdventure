using UnityEngine;

public class Table : Interactor
{
	[Header("Set in Inspector")]
	public GameObject powerUp1;
	public GameObject powerUp2;
    private void Awake()
    {
		powerUp1.SetActive(false);
		powerUp2.SetActive(false);
    }
    protected override void CheckInteraction()
	{
		int holdingCount = 0;
		foreach (var interactableObject in interactableObjects)
		{
			if (interactableObject is HoldingObject)
				holdingCount++;
		}

		if (holdingCount == 3)
		{
			powerUp1.SetActive(true);
			powerUp2.SetActive(true);
			Vector3 pos1 = new Vector3();
			pos1 = transform.position;
			pos1.x += 1;
			Vector3 pos2 = new Vector3();
			pos2 = transform.position;
			pos2.x -= 1;
			powerUp1.transform.position = pos1;
			powerUp2.transform.position = pos2;
		}
	}
}