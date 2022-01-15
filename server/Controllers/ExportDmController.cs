using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Dm1.Data;

namespace Dm1
{
    public partial class ExportDmController : ExportController
    {
        private readonly DmContext context;
        private readonly DmService service;
        public ExportDmController(DmContext context, DmService service)
        {
            this.service = service;
            this.context = context;
        }

        [HttpGet("/export/Dm/attributes/csv")]
        [HttpGet("/export/Dm/attributes/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportAttributesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAttributes(), Request.Query), fileName);
        }

        [HttpGet("/export/Dm/attributes/excel")]
        [HttpGet("/export/Dm/attributes/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportAttributesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAttributes(), Request.Query), fileName);
        }
        [HttpGet("/export/Dm/settings/csv")]
        [HttpGet("/export/Dm/settings/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportSettingsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetSettings(), Request.Query), fileName);
        }

        [HttpGet("/export/Dm/settings/excel")]
        [HttpGet("/export/Dm/settings/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportSettingsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetSettings(), Request.Query), fileName);
        }
    }
}
