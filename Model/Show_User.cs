using System;
using System.Data;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace Model
{
    /// <summary>
    /// 实体类 Show_User, 此类请勿动，以方便表字段更改时重新生成覆盖
    /// </summary>
    [DataContract]
    [Serializable]
    public class Show_User : ICloneable
    {
        public Show_User()
        { }

        #region 实体属性

        /// <summary>
        /// Id
        /// </summary>
        [DataMember]
        public int? Id { get; set; }

        /// <summary>
        /// UserId
        /// </summary>
        [DataMember]
        public string UserId { get; set; }

        /// <summary>
        /// Passcode
        /// </summary>
        [DataMember]
        public string Passcode { get; set; }

        /// <summary>
        /// IsAdmin
        /// </summary>
        [DataMember]
        public bool? IsAdmin { get; set; }

        #endregion

        #region ICloneable 成员

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        #endregion

        public override bool Equals(object obj)
        {
            Model.Show_User model = obj as Model.Show_User;
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