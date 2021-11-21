using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class InteractableObject : MonoBehaviour
{
	public abstract void Interaction();

	[SerializeField] public CharacterMovement character;
	[SerializeField] private float pickUpDistance = 10f;

	private List<Interactor> _interactors; 

	public Vector3 position => transform.position;
	private Dictionary<Interactor, bool> interactionFlags = new Dictionary<Interactor, bool>();


	private void Start()
	{
		_interactors = new List<Interactor>();
		var sceneRootObjects = SceneManager.GetSceneByName("Game").GetRootGameObjects();
		foreach (var go in sceneRootObjects)
		{
			_interactors.AddRange(go.GetComponentsInChildren<Interactor>());
		}
	}

	protected void Update()
	{
		foreach (var interactor in _interactors)
		{
			var distanceWithCharacter = Vector3.Distance(interactor.transform.position, transform.position);
			if (distanceWithCharacter <= pickUpDistance)
			{
				if (InteractorCanInteract(interactor))
					continue;
				interactionFlags[interactor] = true;
				interactor.AddInteractableObject(this);
			}
			else
			{
				if (!InteractorCanInteract(interactor))
					continue;
				interactionFlags[interactor] = false;
				interactor.TryToRemoveInteractableObject(this);
			}
		}
	}

	private bool InteractorCanInteract(Interactor interactor)
	{
		if (!interactionFlags.TryGetValue(interactor, out bool canInteract))
		{
			interactionFlags[interactor] = false;
			return false;
		}

		return interactionFlags[interactor];
	}
}