using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;
using Web.ViewModel;

namespace Web.Services
{
    public interface IBookService
    {
        List<BookVm> Getall();
        List<BookVm> authors();
        Task<bool> Create(BookVm book);

        bool Delete(int? id);

    }
}
