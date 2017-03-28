using MVC_PagingSortingSearching.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_PagingSortingSearching.Models
{
    public class PagingModel
    {
        public int pageSize { get; set; }
        public int TotalRecords { get; set; }
        public IEnumerable<User> User { get; set; }
    }

    public class UserModel
    {
        DataContext context = new DataContext();
        public PagingModel GetUsers(int page, int pageSize, string sort, string sortDir)
        {
            if (pageSize < 0)
                pageSize = 1;

            var data = context.User.Select(m => m);

            switch (sort)
            {
                case "USERID":
                    data = sortDir == "ASC" ? data.OrderBy(u => u.UserId) : data.OrderByDescending(u => u.UserId);
                    break;
                case "NAME":
                    data = sortDir == "ASC" ? data.OrderBy(u => u.Name) : data.OrderByDescending(u => u.Name);
                    break;
                case "ADDRESS":
                    data = sortDir == "ASC" ? data.OrderBy(u => u.Address) : data.OrderByDescending(u => u.Address);
                    break;
                case "CONTACTNO":
                    data = sortDir == "ASC" ? data.OrderBy(u => u.ContactNo) : data.OrderByDescending(u => u.ContactNo);
                    break;
            }

            // grid Paging
            data = data.Skip((page - 1) * pageSize).Take(pageSize);
            PagingModel model = new PagingModel { pageSize = pageSize, TotalRecords = context.User.Count(), User = data };

            return model;
        }

        public PagingModel GetUsers(int page, int pageSize, string sort, string sortDir, string search)
        {
            if (pageSize < 0)
                pageSize = 1;

            var data = context.User.Select(m => m);
            if (!string.IsNullOrEmpty(search))
            {
                data = data.Where(u => u.Name.ToUpper().Contains(search) || u.Address.ToUpper().Contains(search) || u.ContactNo.Contains(search));

            }
            switch (sort)
            {
                case "USERID":
                    data = sortDir == "ASC" ? data.OrderBy(u => u.UserId) : data.OrderByDescending(u => u.UserId);
                    break;
                case "NAME":
                    data = sortDir == "ASC" ? data.OrderBy(u => u.Name) : data.OrderByDescending(u => u.Name);
                    break;
                case "ADDRESS":
                    data = sortDir == "ASC" ? data.OrderBy(u => u.Address) : data.OrderByDescending(u => u.Address);
                    break;
                case "CONTACTNO":
                    data = sortDir == "ASC" ? data.OrderBy(u => u.ContactNo) : data.OrderByDescending(u => u.ContactNo);
                    break;
            }
            int count = data.Count();
            data = data.Skip((page - 1) * pageSize).Take(pageSize);
            PagingModel model = new PagingModel { pageSize = pageSize, TotalRecords = count, User = data };

            return model;
        }
    }
}