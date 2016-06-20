﻿using System;

namespace FluentCassandra.Types
{
	internal class LexicalUUIDTypeConverter : CassandraObjectConverter<Guid>
	{
		public override bool CanConvertFrom(Type sourceType)
		{
			return sourceType == typeof(byte[]) || sourceType == typeof(Guid);
		}

		public override bool CanConvertTo(Type destinationType)
		{
			return destinationType == typeof(byte[]) || destinationType == typeof(Guid);
		}

		public override Guid ConvertFromInternal(object value)
		{
			if (value is byte[] && ((byte[])value).Length == 16)
				return ((byte[])value).FromBytes<Guid>();

			if (value is Guid)
				return (Guid)value;

			return default(Guid);
		}

		public override object ConvertToInternal(Guid value, Type destinationType)
		{
			if (destinationType == typeof(byte[]))
				return value.ToBytes();

			if (destinationType == typeof(Guid))
				return value;

			return null;
		}

		public override byte[] ToBigEndian(Guid value)
		{
			return value.ToBigEndianBytes();
		}

		public override Guid FromBigEndian(byte[] value)
		{
			return value.ToGuidFromBigEndianBytes();
		}
	}
}
