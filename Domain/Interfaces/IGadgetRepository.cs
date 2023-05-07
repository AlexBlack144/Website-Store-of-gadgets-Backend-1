using Domain.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IGadgetRepository : IGenericRepository<Gadget>
    {
        IEnumerable<Gadget> GetbyIdCategory(int id);
        IEnumerable<Gadget> GetGadgetByName(string name);
        IEnumerable<Gadget> GetGadgetFilter(string[]? nameModels, int? min, int? max);
        Task<string> UploadImg(IFormFile uploadedFile,string blobName);
        string GetImgUrl(string name);
    }
}
