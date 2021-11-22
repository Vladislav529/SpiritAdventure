using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Table : Interactor
{
	[SerializeField]
	private List<HoldingObject> suitableObjects; 

	[Header("Set in Inspector")]
	public GameObject powerUp1;
	public GameObject powerUp2;

	[HideInInspector]
	public bool spawned = false;
	private void Awake()
	{
		powerUp1.SetActive(false);
		powerUp2.SetActive(false);
	}
	protected override void CheckInteraction()
	{
		int holdingCount = interactableObjects.AsEnumerable().Count(i => suitableObjects.Contains(i));

		if (holdingCount == 3 && !spawned)
		{
			powerUp1.SetActive(true);
			powerUp2.SetActive(true);
			Vector3 pos1 = new Vector3();
			pos1 = transform.position;
			pos1.x += 3;
			pos1.y += 0.5f;
			Vector3 pos2 = new Vector3();
			pos2 = transform.position;
			pos2.x -= 3;
			pos2.y += 0.5f;
			powerUp1.transform.position = pos1;
			powerUp2.transform.position = pos2;
			spawned = true;
		}
	}
	public override void AddInteractableObject(InteractableObject interactable)
	{
		if (suitableObjects.Contains(interactable))
		{
			base.AddInteractableObject(interactable);
			if (interactable is HoldingObject holdingObject)
            {
				holdingObject.locked = true;
				holdingObject.GetComponent<ParticleSystem>().Stop();
			}
		}
	}
}