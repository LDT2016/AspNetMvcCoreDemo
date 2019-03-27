using IBLL;

namespace DotNetService {
	public interface IServiceFactory {

		/// <summary>
		/// 初始化服务
		/// </summary>
		void InitService();

		/// <summary>
		/// 创建NinjasService
		/// </summary>
		/// <returns>服务接口</returns>
		INinjas CreateNinjas();

		/// <summary>
		/// 创建Show_DoctorsService
		/// </summary>
		/// <returns>服务接口</returns>
		IShow_Doctors CreateShow_Doctors();

		/// <summary>
		/// 创建Show_UserService
		/// </summary>
		/// <returns>服务接口</returns>
		IShow_User CreateShow_User();
	}
}
