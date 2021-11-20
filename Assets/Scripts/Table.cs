using UnityEngine;

public class Table : Interactor
{
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
			foreach (var interactableObject in interactableObjects)
			{
				if (interactableObject is HoldingObject)
					interactableObject.gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.black;
			}
		}
	}
}