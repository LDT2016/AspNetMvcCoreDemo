namespace AspNetMvcCoreDemo.Infrastructure.Data
{
    public class _51DegreeService
    {
        public static _51DegreeService Instance => Holder.Instance;

        private static class Holder
        {
            public static readonly _51DegreeService Instance = new _51DegreeService();
        }
    }
}