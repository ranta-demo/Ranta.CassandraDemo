﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace FluentCassandra.Linq
{
	public class CqlObjectQueryProvider<T> : IQueryable, IQueryable<T>, IQueryProvider, ICassandraColumnFamilyInfo
	{
		private readonly CassandraColumnFamily _family;

		public CqlObjectQueryProvider(CassandraColumnFamily family)
		{
			_family = family;
		}

		public string FamilyName
		{
			get { return _family.FamilyName; }
		}

		public CassandraColumnFamilySchema GetSchema()
		{
			return _family.GetSchema();
		}

		public CqlObjectQuery<T> ToQuery()
		{
			var queryable = (IQueryable)this;
			return new CqlObjectQuery<T>(queryable.Expression, this, _family);
		}

		#region IQueryable Members

		/// <summary>
		/// Gets the type of the element(s) that are returned when the expression tree associated with this instance of <see cref="T:System.Linq.IQueryable"/> is executed.
		/// </summary>
		/// <value></value>
		/// <returns>
		/// A <see cref="T:System.Type"/> that represents the type of the element(s) that are returned when the expression tree associated with this object is executed.
		/// </returns>
		public virtual Type ElementType
		{
			get { return typeof(T); }
		}

		/// <summary>
		/// Gets the expression tree that is associated with the instance of <see cref="T:System.Linq.IQueryable"/>.
		/// </summary>
		/// <value></value>
		/// <returns>
		/// The <see cref="T:System.Linq.Expressions.Expression"/> that is associated with this instance of <see cref="T:System.Linq.IQueryable"/>.
		/// </returns>
		Expression IQueryable.Expression
		{
			get { return Expression.Constant(this); }
		}

		/// <summary>
		/// Gets the query provider that is associated with this data source.
		/// </summary>
		/// <value></value>
		/// <returns>
		/// The <see cref="T:System.Linq.IQueryProvider"/> that is associated with this data source.
		/// </returns>
		IQueryProvider IQueryable.Provider
		{
			get { return this; }
		}


		#endregion

		#region IEnumerable Members

		/// <summary>
		/// Returns an enumerator that iterates through a collection.
		/// </summary>
		/// <returns>
		/// An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.
		/// </returns>
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ToQuery().GetEnumerator();
		}

		#endregion

		#region IEnumerable<ICqlRow> Members

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			return ToQuery().GetEnumerator();
		}

		#endregion

		#region IQueryProvider Members

		public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
		{
			return new CqlObjectQuery<TElement>(expression, this, _family);
		}

		public IQueryable CreateQuery(Expression expression)
		{
			throw new NotImplementedException();
		}

		public TResult Execute<TResult>(Expression expression)
		{
			if (expression.NodeType == ExpressionType.Call)
				expression = ((MethodCallExpression)expression).Arguments[0];

			var result = new CqlObjectQuery<TResult>(expression, this, _family);
			return Enumerable.FirstOrDefault(result);
		}

		public object Execute(Expression expression)
		{
			throw new NotImplementedException();
		}

		#endregion
	}
}
