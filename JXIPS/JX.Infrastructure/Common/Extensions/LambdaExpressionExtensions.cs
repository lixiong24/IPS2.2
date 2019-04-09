using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace JX.Infrastructure.Common
{
	/// <summary>
	/// 对Lambda表达式的扩展
	/// </summary>
	public static class LambdaExpressionExtensions
    {
		#region 实体转换
		/// <summary>
		/// 转换一个实体表达式到另一个实体表达式，主要用于entity和dto之间的表达式转换
		/// </summary>
		/// <typeparam name="TInput"></typeparam>
		/// <typeparam name="TToProperty"></typeparam>
		/// <param name="expression"></param>
		/// <returns></returns>
		public static Expression<Func<TToProperty, bool>> Cast<TInput, TToProperty>(this Expression<Func<TInput, bool>> expression)
		{
			var p = Expression.Parameter(typeof(TToProperty), "p");
			var x = Parser(p, expression);
			return Expression.Lambda<Func<TToProperty, bool>>(x, p);
		}
		/// <summary>
		/// 转换一个实体表达式到另一个实体表达式，主要用于entity和dto之间的表达式转换
		/// </summary>
		/// <typeparam name="TInput"></typeparam>
		/// <typeparam name="TToProperty"></typeparam>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="expression"></param>
		/// <returns></returns>
		public static Expression<Func<TToProperty, TResult>> Cast<TInput, TToProperty, TResult>(this Expression<Func<TInput, TResult>> expression)
		{
			var p = Expression.Parameter(typeof(TToProperty), "p");
			var x = Parser(p, expression);
			return Expression.Lambda<Func<TToProperty, TResult>>(x, p);
		}

		private static Expression Parser(ParameterExpression parameter, Expression expression)
		{
			if (expression == null) return null;
			switch (expression.NodeType)
			{
				//一元运算符
				case ExpressionType.Negate:
				case ExpressionType.NegateChecked:
				case ExpressionType.Not:
				case ExpressionType.Convert:
				case ExpressionType.ConvertChecked:
				case ExpressionType.ArrayLength:
				case ExpressionType.Quote:
				case ExpressionType.TypeAs:
					{
						var unary = expression as UnaryExpression;
						var exp = Parser(parameter, unary.Operand);
						return Expression.MakeUnary(expression.NodeType, exp, unary.Type, unary.Method);
					}
				//二元运算符
				case ExpressionType.Add:
				case ExpressionType.AddChecked:
				case ExpressionType.Subtract:
				case ExpressionType.SubtractChecked:
				case ExpressionType.Multiply:
				case ExpressionType.MultiplyChecked:
				case ExpressionType.Divide:
				case ExpressionType.Modulo:
				case ExpressionType.And:
				case ExpressionType.AndAlso:
				case ExpressionType.Or:
				case ExpressionType.OrElse:
				case ExpressionType.LessThan:
				case ExpressionType.LessThanOrEqual:
				case ExpressionType.GreaterThan:
				case ExpressionType.GreaterThanOrEqual:
				case ExpressionType.Equal:
				case ExpressionType.NotEqual:
				case ExpressionType.Coalesce:
				case ExpressionType.ArrayIndex:
				case ExpressionType.RightShift:
				case ExpressionType.LeftShift:
				case ExpressionType.ExclusiveOr:
					{
						var binary = expression as BinaryExpression;
						var left = Parser(parameter, binary.Left);
						var right = Parser(parameter, binary.Right);
						var conversion = Parser(parameter, binary.Conversion);
						if (binary.NodeType == ExpressionType.Coalesce && binary.Conversion != null)
						{
							return Expression.Coalesce(left, right, conversion as LambdaExpression);
						}
						else
						{
							return Expression.MakeBinary(expression.NodeType, left, right, binary.IsLiftedToNull, binary.Method);
						}
					}
				//其他
				case ExpressionType.Call:
					{
						var call = expression as MethodCallExpression;
						List<Expression> arguments = new List<Expression>();
						foreach (var argument in call.Arguments)
						{
							arguments.Add(Parser(parameter, argument));
						}
						var instance = Parser(parameter, call.Object);
						call = Expression.Call(instance, call.Method, arguments);
						return call;
					}
				case ExpressionType.Lambda:
					{
						var Lambda = expression as LambdaExpression;
						return Parser(parameter, Lambda.Body);
					}
				case ExpressionType.MemberAccess:
					{
						var memberAccess = expression as MemberExpression;
						if (memberAccess.Expression == null)
						{
							memberAccess = Expression.MakeMemberAccess(null, memberAccess.Member);
						}
						else
						{
							var exp = Parser(parameter, memberAccess.Expression);
							var member = exp.Type.GetMember(memberAccess.Member.Name).FirstOrDefault();
							memberAccess = Expression.MakeMemberAccess(exp, member);
						}
						return memberAccess;
					}
				case ExpressionType.Parameter:
					return parameter;
				case ExpressionType.Constant:
					return expression;
				case ExpressionType.TypeIs:
					{
						var typeis = expression as TypeBinaryExpression;
						var exp = Parser(parameter, typeis.Expression);
						return Expression.TypeIs(exp, typeis.TypeOperand);
					}
				default:
					throw new Exception(string.Format("未知的表达式类型: '{0}'", expression.NodeType));
			}
		}
		#endregion

		#region 表达式拼接
		/// <summary>
		/// 实现表达式的AND拼接
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="expr1"></param>
		/// <param name="expr2"></param>
		/// <returns></returns>
		public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
		{
			var newExp = Expression.Lambda<Func<T, bool>>(Expression.AndAlso(expr1.Body, expr2.Body), expr1.Parameters);
			var visitor = new ParameterReplacementVisitor(expr1.Parameters[0]);
			return (Expression<Func<T, bool>>)visitor.Visit(newExp);
		}
		/// <summary>
		/// 实现表达式的OR拼接
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="expr1"></param>
		/// <param name="expr2"></param>
		/// <returns></returns>
		public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
		{
			var newExp = Expression.Lambda<Func<T, bool>>(Expression.OrElse(expr1.Body, expr2.Body), expr1.Parameters);
			var visitor = new ParameterReplacementVisitor(expr1.Parameters[0]);
			return (Expression<Func<T, bool>>)visitor.Visit(newExp);
		}
		#endregion
	}

	/// <summary>
	/// 用于在拼接Lambda表达式时，替换参数部分为同一个参数。
	/// </summary>
	public class ParameterReplacementVisitor : ExpressionVisitor
	{
		private readonly ParameterExpression _parameter;

		/// <summary>
		/// 构造器注入
		/// </summary>
		/// <param name="parameter"></param>
		public ParameterReplacementVisitor(ParameterExpression parameter)
		{
			_parameter = parameter;
		}

		/// <summary>
		/// 得到参数表达式
		/// </summary>
		public ParameterExpression Parameter
		{
			get { return _parameter; }
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="node"></param>
		/// <returns></returns>
		protected override Expression VisitParameter(ParameterExpression node)
		{
			if (node.Name == _parameter.Name)
			{
				return _parameter;
			}

			return base.VisitParameter(node);
		}
	}
}
