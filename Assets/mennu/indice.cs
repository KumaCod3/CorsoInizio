using UnityEngine;

public class indice: MonoBehaviour
{
	public int index;

	public int getIndex()
	{
		return index;
	}
	// Start is called before the first frame update
	public void DropdownSample(int ind)
	{
		index = ind;
	}
}
