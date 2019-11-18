namespace ApiDemo.Models
{
    public class UploadImageBO : UserImageBO
    {
        #region constructors

        public UploadImageBO() : base(UserImageType.Upload) { }

        #endregion
    }
}
