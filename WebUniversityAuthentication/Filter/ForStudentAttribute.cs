﻿using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUniversityAuthentication.Filter
{
    public class ForStudentAttribute : Attribute, IFilterFactory
    {
            public IFilterMetadata CreateInstance(IServiceProvider serviceProvider) =>
                new ForStudentFilter();

            public bool IsReusable => false;
        }
    
}
