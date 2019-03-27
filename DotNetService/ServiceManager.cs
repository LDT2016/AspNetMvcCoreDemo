using System;
using IBLL;

namespace DotNetService {
	public class ServiceManager : AbstractServiceFactory {

	    private static readonly string servicePath = "BLL";
		private static readonly string serviceFactoryClass = "ServiceFactory";

		public ServiceManager() {
			serviceFactory = GetServiceFactory(servicePath, serviceFactoryClass);
		}

		private IServiceFactory serviceFactory = null;

		public void InitService() {
			serviceFactory.InitService();
		}

		// 这里不能继续用单实例了，会遇到WCF回收资源的问题

		private static ServiceManager instance = null;
		private static object locker = new Object();

		public static ServiceManager Instance {
			get {
				if (instance == null) {
					lock (locker) {
						if (instance == null) {
							instance = new ServiceManager();
						}
					}
				}
				return instance;
			}
		}

		public virtual INinjas Ninjas {
			get {
				return serviceFactory.CreateNinjas();
			}
		}

		public virtual IShow_Doctors Show_Doctors {
			get {
				return serviceFactory.CreateShow_Doctors();
			}
		}

		public virtual IShow_User Show_User {
			get {
				return serviceFactory.CreateShow_User();
			}
		}
	}
}
