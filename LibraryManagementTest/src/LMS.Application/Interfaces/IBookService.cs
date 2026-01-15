using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LMS.API.DTOs;
using LMS.Application.DTOs;
using LMS.Domain.Entities;

namespace LMS.Application.Interfaces
{
    public interface IBookService
    {
        Task<List<ResponseBookDto>> GetAllBooksAsync();

        Task<Guid> AddBookAsync(CreateBookDto createBookDto);
        Task<bool> UpdateBookAsync(UpdateBook updateBook,Guid id);
    }
}
