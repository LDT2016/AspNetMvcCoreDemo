using System;
using System.Web.Services;
using System.ComponentModel;
using System.Collections.Generic;
using System.ServiceModel;
using System.Data;
using IBLL;

namespace BLL
{
    /// <summary>
    /// 业务逻辑类 Show_Doctors
    /// </summary>
    [ServiceBehavior(IncludeExceptionDetailInFaults = true, InstanceContextMode = InstanceContextMode.PerSession)]
    public class Show_Doctors: IShow_Doctors
    {
        private static readonly DAL.Show_Doctors dal = new DAL.Show_Doctors();

        public Show_Doctors(){}

        [WebMethod(Description="增加一条数据")]
        public int Add(Model.Show_Doctors model)
        {
            return dal.Add(model);
        }

        [WebMethod(Description="更新一条数据")]
        public int Update(Model.Show_Doctors model)
        {
            return dal.Update(model);
        }

        [WebMethod(Description="删除一条数据")]
        public int Delete(int? Id)
        {
            return dal.Delete(Id);
        }

        [WebMethod(Description="清空所有数据")]
        public int Truncate()
        {
            return dal.Truncate();
        }

        [WebMethod(Description="获取DataTable数据列表")]
        public DataTable GetDataTable(string strWhere = "",string strOrder = "")
        {
            return dal.GetDataTable(strWhere,strOrder);
        }

        [WebMethod(Description="获取DataSet数据列表")]
        public DataSet GetDataSet(string strWhere = "",string strOrder = "")
        {
            return dal.GetDataSet(strWhere,strOrder);
        }

        public DataView GetDataView(string strWhere = "",string strOrder = "")
        {
            return dal.GetDataView(strWhere,strOrder);
        }

        [WebMethod(Description="是否存在该记录")]
        public bool Exists(int? Id)
        {
            bool bln = dal.Exists(Id);
            return bln;
        }

        [WebMethod(Description="得到一个对象实体")]
        public Model.Show_Doctors GetModel(int? Id)
        {
            Model.Show_Doctors model = dal.GetModel(Id);
            return model;
        }

        [WebMethod(Description="获取数量")]
        public int GetCount(string strWhere = "")
        {
            return dal.GetCount(strWhere);
        }

        [WebMethod(Description="获取最大ID")]
        public int GetMaxId()
        {
            return dal.GetMaxId();
        }

        [WebMethod(Description="获得泛型数据列表")]
        public List<Model.Show_Doctors> GetList(string strWhere = "",string strOrder = "")
        {
            List<Model.Show_Doctors> lst = dal.GetList(strWhere,strOrder);
            return lst;
        }

        [WebMethod(Description="根据每页记录数及所要获取的页数")]
        public Model.PageData GetPageList(int pageSize, int curPage, string strWhere, string strOrder)
        {
            return dal.GetPageList(pageSize, curPage, strWhere, strOrder);
        }

        [WebMethod(Description="分页获取数据列表")]
        public List<Model.Show_Doctors> GetListByPage(string strWhere, string strOrder, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, strOrder, startIndex, endIndex);
        }
    }
}
