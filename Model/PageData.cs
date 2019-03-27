using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    /// <summary>
    /// 对象名称：数据分页实体类（数据实体层）
    /// 对象说明：主要用于数据访问层与用户界面层中的PageBar分页控件进行数据交互。
    /// </summary>
    public class PageData
    {
        /// <summary>
        /// [属性]分页过后的数据。
        /// </summary>
        private IList pageList;

        public IList PageList
        {
            get { return pageList; }
            set { pageList = value; }
        }

        /// <summary>
        /// [属性]每页显示记录数。
        /// </summary>
        private int pageSize;

        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = value; }
        }

        /// <summary>
        /// [属性]所请求的当前页数。
        /// </summary>
        private int curPage;

        public int CurPage
        {
            get { return curPage; }
            set { curPage = value; }
        }

        /// <summary>
        /// [属性]总页数。
        /// </summary>
        private int pageCount;

        public int PageCount
        {
            get { return pageCount; }
            set { pageCount = value; }
        }

        /// <summary>
        /// [属性]总记录数。
        /// </summary>
        private int recordCount;

        public int RecordCount
        {
            get { return recordCount; }
            set { recordCount = value; }
        }

        /// <summary>
        /// [属性]相对于当前页的上一页
        /// </summary>
        private int prevPage;

        public int PrevPage
        {
            get
            {
                if (CurPage > 1)
                {
                    return CurPage - 1;
                }
                return 1;
            }
        }

        /// <summary>
        /// [属性]相对于当前页的下一页
        /// </summary>
        private int nextPage;

        public int NextPage
        {
            get
            {
                if (CurPage < PageCount)
                {
                    return CurPage + 1;
                }
                return PageCount;
            }
        }
    }
}
