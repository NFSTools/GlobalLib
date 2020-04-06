using GlobalLib.Reflection.Attributes;
using GlobalLib.Reflection.Enum;
using System;

namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class BankTrigger
	{
		private eBoolean _initially_unlocked = eBoolean.False;

		[AccessModifiable()]
		[StaticModifiable()]
		public ushort CashValue { get; set; }

		[AccessModifiable()]
		[StaticModifiable()]
		public eBoolean InitiallyUnlocked
		{
			get => this._initially_unlocked;
			set
			{
				if (Enum.IsDefined(typeof(eBoolean), value))
					this._initially_unlocked = value;
				else
					throw new ArgumentOutOfRangeException("Value passed is not of boolean type.");
			}
		}

		[AccessModifiable()]
		public byte BankIndex { get; set; }

		[AccessModifiable()]
		[StaticModifiable()]
		public int RequiredStagesCompleted { get; set; }
	}
}