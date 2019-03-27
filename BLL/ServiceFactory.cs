using DotNetService;
using IBLL;

namespace BLL {

	public class ServiceFactory : IServiceFactory {
		public void InitService() {
		}

		public virtual INinjas CreateNinjas() {
			return new Ninjas();
		}

		public virtual IShow_Doctors CreateShow_Doctors() {
			return new Show_Doctors();
		}

		public virtual IShow_User CreateShow_User() {
			return new Show_User();
		}
	}
}

