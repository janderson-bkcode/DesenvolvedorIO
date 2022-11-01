using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Site.Services
{
	public class OperacaoService
	{
		public IOperacaoTransient Transient { get; }
		public IOperacaoScoped Scoped { get; }
		public IOperacaoSingleton Singleton { get; }
		public IOperacaoSingletonInstance SingletonInstance { get; }

		public OperacaoService(IOperacaoTransient transient, IOperacaoScoped scoped , IOperacaoSingleton singleton, IOperacaoSingletonInstance singletonInstance)
		{
			Transient = transient;
			Scoped = scoped;
			Singleton = singleton;
			SingletonInstance = singletonInstance;
		}

			
	}

	public class Operacao : IOperacaoTransient, IOperacaoScoped, IOperacaoSingleton, IOperacaoSingletonInstance
	{
		public Operacao() : this(Guid.NewGuid())
		{

		}

		public Operacao(Guid id)
		{
			OperacaoId = id;
		}

		public Guid OperacaoId { get; private set; }
	}

	public interface IOperacaoTransient:IOperacao
	{
	}

	public interface IOperacao
	{
		Guid OperacaoId { get; }
	}
	public interface IOperacaoScoped : IOperacao
	{
	}
	public interface IOperacaoSingleton : IOperacao
	{
	}
	public interface IOperacaoSingletonInstance : IOperacao
	{
	}
}
