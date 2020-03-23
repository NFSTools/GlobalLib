namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class PartUnlockable
	{
		private string GetValidCollectionName(int index)
		{
			if (index > Framework.PartCNames.PartUnlockablesList.Count)
				return $"UnknownPart{index}";
			else
				return Framework.PartCNames.PartUnlockablesList[index - 1];
		}

		private int GetValidCollectionIndex()
		{
			if (Framework.PartCNames.PartUnlockablesList.Contains(this._collection_name))
				return Framework.PartCNames.PartUnlockablesList.FindIndex(c => c == this._collection_name) + 1;
			else
				return Framework.PartCNames.PartUnlockablesList.Count + 1;
		}
	}
}