﻿using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface INationalityRepository
    {
        public List<Nationality> GetAllNationalities();
    }
}
