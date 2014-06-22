using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonelByKathy.Models;
using PersonelByKathy.ViewModels;

namespace PersonelByKathy.Abstract
{
    public interface IJobRepository
    { 
        //place a reference to all CRUD methods here
         JobViewModel GetJobsByUser(string UserloggedIn);
       
    }
}
