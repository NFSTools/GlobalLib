namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class GShowcase
	{
		private Reflection.Enum.eTakePhotoMethod _take_photo = Reflection.Enum.eTakePhotoMethod.MAGAZINE_YOURSELF;

		[Reflection.Attributes.AccessModifiable()]
		[Reflection.Attributes.StaticModifiable()]
		public Reflection.Enum.eTakePhotoMethod TakePhotoMethod
		{
			get => this._take_photo;
			set
			{
				if (System.Enum.IsDefined(typeof(Reflection.Enum.eTakePhotoMethod), value))
					this._take_photo = value;
				else
					throw new Reflection.Exception.MappingFailException();
			}
		}

		[Reflection.Attributes.AccessModifiable()]
		[Reflection.Attributes.StaticModifiable()]
		public byte BelongsToStage { get; set; }

		[Reflection.Attributes.AccessModifiable()]
		[Reflection.Attributes.StaticModifiable()]
		public short CashValue { get; set; }

		[Reflection.Attributes.AccessModifiable()]
		[Reflection.Attributes.StaticModifiable()]
		public float RequiredVisualRating { get; set; }
	}
}