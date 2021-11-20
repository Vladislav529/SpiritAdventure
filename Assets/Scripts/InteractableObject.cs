using UnityEngine;

public abstract class InteractableObject : MonoBehaviour
{
	public abstract void Interaction();

	[SerializeField] private CharacterMovement character;
	[SerializeField] private float pickUpDistance = 10f;

	public Vector3 position => transform.position;
	private bool _characterCanInteract;


	protected void Update()
	{
        
		var distanceWithCharacter = Vector3.Distance(character.transform.position, transform.position);
		if (distanceWithCharacter <= pickUpDistance)
		{
			if (_characterCanInteract)
				return;
			_characterCanInteract = true;
			character.AddInteractableObject(this);
		}
		else
		{
			if (!_characterCanInteract)
				return;
			_characterCanInteract = false;
			character.TryToRemoveInteractableObject(this);
		}
	}
}