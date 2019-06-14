using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class InfiniteHorizontalScroll : InfiniteScroll
{
	[SerializeField] private float m_TempVelocity;
	Vector2 tempVelocity = new Vector2();

	protected override void Update()
	{
		base.Update ();
		tempVelocity.x = m_TempVelocity;
		velocity = tempVelocity;
	}

	protected override float GetSize (RectTransform item)
	{
		return item.GetComponent<LayoutElement> ().minWidth + content.GetComponent<HorizontalLayoutGroup> ().spacing;
	}

	protected override float GetDimension (Vector2 vector)
	{
		return vector.x;
	}

	protected override Vector2 GetVector (float value)
	{
		return new Vector2 (-value, 0);
	}

	protected override float GetPos (RectTransform item)
	{
		return -item.localPosition.x - content.localPosition.x;
	}

	protected override int OneOrMinusOne ()
	{
		return -1;
	}
}
