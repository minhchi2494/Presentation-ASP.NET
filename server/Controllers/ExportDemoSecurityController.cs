using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Dm1.Data;

namespace Dm1
{
    public partial class ExportDemoSecurityController : ExportController
    {
        private readonly DemoSecurityContext context;
        private readonly DemoSecurityService service;
        public ExportDemoSecurityController(DemoSecurityContext context, DemoSecurityService service)
        {
            this.service = service;
            this.context = context;
        }

    }
}
