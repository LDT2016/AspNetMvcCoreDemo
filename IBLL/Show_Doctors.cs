using System;
using System.Data;
using System.ServiceModel;
using System.Collections.Generic;

namespace IBLL
{
	/// <summary>
	/// 接口层 IShow_Doctors
	/// </summary>
	[ServiceContract]
	public interface IShow_Doctors
	{
		/// <summary>
		/// 增加一条数据
		/// </summary>
	    [OperationContract(IsOneWay = false)]
		int Add(Model.Show_Doctors model);

		/// <summary>
		/// 更新一条数据
		/// </summary>
	    [OperationContract(IsOneWay = false)]
		int Update(Model.Show_Doctors model);

		/// <summary>
		/// 删除一条数据
		/// </summary>
	    [OperationContract(IsOneWay = false)]
		int Delete(int? Id);

		/// <summary>
		/// 清空所有数据
		/// </summary>
	    [OperationContract(IsOneWay = false)]
		int Truncate();

		/// <summary>
		/// 获取DataTable数据列表
		/// </summary>
	    [OperationContract(IsOneWay = false)]
		DataTable GetDataTable(string strWhere = "", string strOrder = "");

		/// <summary>
		/// 获取DataSet数据列表
		/// </summary>
	    [OperationContract(IsOneWay = false)]
		DataSet GetDataSet(string strWhere = "", string strOrder = "");

		/// <summary>
		/// 获取DataView数据列表
		/// </summary>
	    [OperationContract(IsOneWay = false)]
		DataView GetDataView(string strWhere = "", string strOrder = "");

		/// <summary>
		/// 是否存在该记录
		/// </summary>
	    [OperationContract(IsOneWay = false)]
		bool Exists(int? Id);

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
	    [OperationContract(IsOneWay = false)]
		Model.Show_Doctors GetModel(int? Id);

		/// <summary>
		/// 获取数据条数
		/// </summary>
	    [OperationContract(IsOneWay = false)]
		int GetCount(string strWhere = "");

		/// <summary>
		/// 获取最大ID
		/// </summary>
	    [OperationContract(IsOneWay = false)]
		int GetMaxId();

		/// <summary>
		/// 获取泛型数据列表
		/// </summary>
	    [OperationContract(IsOneWay = false)]
		List<Model.Show_Doctors> GetList(string strWhere = "",string strOrder = "");

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
	    [OperationContract(IsOneWay = false)]
		Model.PageData GetPageList(int pageSize, int curPage, string strWhere, string strOrder);

		/// <summary>
		/// 分页获取泛型数据列表
		/// </summary>
	    [OperationContract(IsOneWay = false)]
		List<Model.Show_Doctors> GetListByPage(string strWhere, string orderby, int startIndex, int endIndex);
	}
}
