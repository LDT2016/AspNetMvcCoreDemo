namespace ApiDemo.Models
{
    public abstract class UserImageBO
    {
        #region constructors

        public UserImageBO() { }

        public UserImageBO(UserImageType type)
        {
            Type = type;
        }

        #endregion

        #region properties

        public UserImageType Type { get; }

        #endregion
    }
}
