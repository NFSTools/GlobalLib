namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class BankTrigger
	{
		private Reflection.Enum.eBoolean _initially_unlocked = Reflection.Enum.eBoolean.False;

		[Reflection.Attributes.AccessModifiable()]
		[Reflection.Attributes.StaticModifiable()]
		public ushort CashValue { get; set; }

		[Reflection.Attributes.AccessModifiable()]
		[Reflection.Attributes.StaticModifiable()]
		public Reflection.Enum.eBoolean InitiallyUnlocked
		{
			get => this._initially_unlocked;
			set
			{
				if (System.Enum.IsDefined(typeof(Reflection.Enum.eBoolean), value))
					this._initially_unlocked = value;
				else
					throw new System.ArgumentOutOfRangeException("Value passed is not of boolean type.");
			}
		}

		[Reflection.Attributes.AccessModifiable()]
		public byte BankIndex { get; set; }

		[Reflection.Attributes.AccessModifiable()]
		[Reflection.Attributes.StaticModifiable()]
		public int RequiredStagesCompleted { get; set; }
	}
}