using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiDemo.Models;

namespace ApiDemo.Interface
{
    public interface ITestProductService
    {
        Task<IList<TestProduct>> GetTestProduct();

        Task<IList<int>> GetProductVendorId(string itemId);
        Task<IList<ImprintColorModel>> GetImprintColors(string itemId, object imprintAreaCode);
        Task<List<ImprintFormatData>> GetImprintFormat(string itemId);
        Task<ImprintAreaHeaderModel> GetImprintAreaHeader(string imprintAreaCode);
        Task<int> GetVerseSequenceByImageCode(string imprintAreaCode, string pptfeCode);
        Task<bool> AllowAutoDefaultVerse(string imprintAreaCode, string pptfeCode);
        Task<int> GetSentimentSequenceByImageCode(string imprintAreaCode, string pptfeCode);
    }
}
