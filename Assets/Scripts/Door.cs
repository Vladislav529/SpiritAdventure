using UnityEngine;

public class Door : InteractableObject
{
	[SerializeField] private Collider2D _doorCollider2D;
	[SerializeField] private GameObject openedSprite;
	[SerializeField] private GameObject closedSprite;
	public override void Interaction()
	{
		GameObject colliderGO = _doorCollider2D.gameObject;
		_doorCollider2D.gameObject.SetActive(!colliderGO.activeSelf);
		openedSprite.SetActive(!colliderGO.activeSelf);
		closedSprite.SetActive(colliderGO.activeSelf);
	}
}