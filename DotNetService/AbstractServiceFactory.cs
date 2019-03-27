using System.Reflection;

namespace DotNetService {

	public abstract class AbstractServiceFactory {
		private static readonly string servicePath = "BLL";
		public AbstractServiceFactory() {
		}

		public virtual IServiceFactory GetServiceFactory() {
			return GetServiceFactory(servicePath);
		}

		public virtual IServiceFactory GetServiceFactory(string servicePath) {
			string className = servicePath + ".ServiceFactory";
			return (IServiceFactory)Assembly.Load(servicePath).CreateInstance(className);
		}

		public virtual IServiceFactory GetServiceFactory(string servicePath, string serviceFactoryClass) {
			string className = servicePath + "." + serviceFactoryClass;
			return (IServiceFactory)Assembly.Load(servicePath).CreateInstance(className);
		}
	}
}
