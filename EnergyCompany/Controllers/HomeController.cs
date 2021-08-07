using EnergyCompany.Data;
using EnergyCompany.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EnergyCompany.Controllers
{
    public class HomeController : Controller
    {
        private readonly EnergyCompanyContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(EnergyCompanyContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        [ActionName("meter-reading-uploads")]
        public IActionResult UploadMeterReadings()
        {
            // grab the file
            var file = Request.Form.Files[0];

            var contents = string.Empty;

            var result = new CSVFileUploadResult();            

            var meterReadings = new List<MeterReading>();

            // open reader
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                var line = reader.ReadLine();
                var headers = line.Split(',');

                while (!reader.EndOfStream)
                {
                    line = reader.ReadLine();

                    var row = line.Split(',');

                    if (row.Length < headers.Length)
                    {
                        result.FailedCount++;                        
                        continue;
                    }

                    var reading = ParseMeterReading(row);

                    if (reading == null)
                    {
                        result.FailedCount++;
                        continue;
                    }
                    else
                    {
                        meterReadings.Add(reading);
                    }

                    result.SuccessCount++;
                }
            }

            _context.MeterReadings.AddRange(meterReadings);

            _context.SaveChanges();

            return View(result);
        }
        
        private MeterReading ParseMeterReading(string[] row)
        {
            if (row.Length != 3)
            {
                return null;
            }
            
            var result = new MeterReading();

            if (!int.TryParse(row[0], out var id))
            {
                return null;
            }
            
            if (!_context.Accounts.Any(a => a.AccountId == id))
            {
                return null;
            }

            if (!DateTime.TryParse(row[1], out var date))
            {
                return null;
            }

            if (!int.TryParse(row[2], out var value))
            {
                return null;
            }

            result.AccountId = id;
            result.Date = date;
            result.Value = value;

            return result;
        }
    }        
}
