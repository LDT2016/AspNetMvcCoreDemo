using System;
using System.Data;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace Model
{
    /// <summary>
    /// 实体类 Ninjas, 此类请勿动，以方便表字段更改时重新生成覆盖
    /// </summary>
    [DataContract]
    [Serializable]
    public class Ninjas : ICloneable
    {
        public Ninjas()
        { }

        #region 实体属性

        /// <summary>
        /// Id
        /// </summary>
        [DataMember]
        public int? Id { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        #endregion

        #region ICloneable 成员

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        #endregion

        public override bool Equals(object obj)
        {
            Model.Ninjas model = obj as Model.Ninjas;
            if (model != null && model.Id == this.Id)
                return true;

            return false;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}