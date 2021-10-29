using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Data;
using System.Globalization;
using System;
using System.IO;
using System.Collections.Generic;
using LumenWorks.Framework.IO.Csv;
using Newtonsoft.Json;
public class BodyInput
{
    public string country { get; set; }
    public string[] linesOfBusiness { get; set; }
}

namespace Galytix.WebApi.Controllers
{
    [Route("/api/")]
    public class CountryGwpController : Controller
    {
        [AllowAnonymous]
        [HttpPost]
        [Route("gwp/avg")]
        public JsonResult CountryGwp([FromBody]BodyInput bi)
        {
            CultureInfo cultures = new CultureInfo("en-US");
            Dictionary<string, decimal> finalOutput = new Dictionary<string, decimal>();
            var csvTable = new DataTable();  
            using (var csvReader = new CsvReader(new StreamReader(System.IO.File.OpenRead(@".\Data\gwpByCountry.csv")), true))  
            {  
                csvTable.Load(csvReader);  
            }
            foreach (string s in bi.linesOfBusiness){
                DataRow[] rslt = csvTable.Select("country = '" + bi.country + "' AND lineOfBusiness = '" + s + "'");
                finalOutput.Add(s,Decimal.Divide((rslt[0]["Y2008"] == DBNull.Value ? 0 :(Convert.ToDecimal(rslt[0]["Y2008"], cultures))) + (rslt[0]["Y2009"] == DBNull.Value ? 0 :(Convert.ToDecimal(rslt[0]["Y2009"], cultures))) + (rslt[0]["Y2010"] == DBNull.Value ? 0 :(Convert.ToDecimal(rslt[0]["Y2010"], cultures))) + (rslt[0]["Y2011"] == DBNull.Value ? 0 :(Convert.ToDecimal(rslt[0]["Y2011"], cultures))) + (rslt[0]["Y2012"] == DBNull.Value ? 0 :(Convert.ToDecimal(rslt[0]["Y2012"], cultures))) + (rslt[0]["Y2013"] == DBNull.Value ? 0 :(Convert.ToDecimal(rslt[0]["Y2013"], cultures))) + (rslt[0]["Y2014"] == DBNull.Value ? 0 :(Convert.ToDecimal(rslt[0]["Y2014"], cultures))) + (rslt[0]["Y2015"] == DBNull.Value ? 0 :(Convert.ToDecimal(rslt[0]["Y2015"], cultures))),8.0m));
            }
            return Json(JsonConvert.SerializeObject(finalOutput));
        }
    }
}
