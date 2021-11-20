using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class InteractableObject : MonoBehaviour
{
	public abstract void Interaction();

	[SerializeField] private CharacterMovement character;
	[SerializeField] private float pickUpDistance = 10f;

	private List<Interactor> _interactors; 

	public Vector3 position => transform.position;
	private bool _characterCanInteract;


	private void Start()
	{
		_interactors = new List<Interactor>();
		foreach (var go in SceneManager.GetActiveScene()
			.GetRootGameObjects())
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
				if (_characterCanInteract)
					return;
				_characterCanInteract = true;
				interactor.AddInteractableObject(this);
			}
			else
			{
				if (!_characterCanInteract)
					return;
				_characterCanInteract = false;
				interactor.TryToRemoveInteractableObject(this);
			}
		}
	}
}