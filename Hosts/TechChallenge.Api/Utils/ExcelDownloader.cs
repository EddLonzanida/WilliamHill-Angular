using OfficeOpenXml;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Hosting;
using TechChallenge.Business.Common.Entities;
using TechChallenge.Data.Contracts;

namespace TechChallenge.Api.Utils
{
    public static class ExcelUtil
    {
        public static ExcelPackage CreateCustomerExcel(string fileName)
        {
            const string AUTHOR = "Noel";
            const string APPLICATION = "Willian Hill";
            const string COMPANY = "Willian Hill Corp.";
            const string XLT_FOLDER = "ExcelTemplates";

            var xltFolder = HostingEnvironment.MapPath($@"~\bin\{XLT_FOLDER}");
            var xltPath = $"{Path.Combine(xltFolder, "Customers.xltx")}";
            var fn = $"{fileName}_{DateTime.Now.ToString("yyyMMddhhmmss")}.xlsx";
            var xls = new ExcelPackage(new FileInfo(xltPath), true);

            xls.Workbook.Properties.Author = AUTHOR;
            xls.Workbook.Properties.Application = APPLICATION;
            xls.Workbook.Properties.Company = COMPANY;
            xls.Workbook.Properties.Title = fn;// fn;
            xls.Workbook.Properties.Category = APPLICATION;

            return xls;
        }

        public static async Task<MemoryStream> GetCustomers(IDataRepositorySoftDeleteInt<Customer> repository, ExcelPackage xls)
        {
            const int ROWS_TO_INSERT = 1;

            var items = await repository.GetAllAsync();
            var ws = xls.Workbook.Worksheets.First();
            var rStart = ws.Workbook.Names["rStart"]; //starting point
            var startRow = rStart.Start.Row;
            var copyFromRow = startRow;
            var rowOffset = 1;

            items.ForEach(r =>
            {
                ws.InsertRow(startRow + rowOffset, ROWS_TO_INSERT, copyFromRow); //insert row below rStart and use the row styles of rStart
                rStart.Offset(rowOffset, 0).Value = r.Id;
                rStart.Offset(rowOffset, 1).Value = r.Name;

                rowOffset++;
            });

            ws.DeleteRow(startRow + rowOffset); //delete last row
            ws.DeleteRow(startRow); //delete start row

            var memoryStream = new MemoryStream();

            xls.SaveAs(memoryStream);
            memoryStream.Position = 0;

            return memoryStream;
        }
    }
}