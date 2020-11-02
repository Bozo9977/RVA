using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Helpers;
using Common.Models;
using Server.DatabaseAccess;

namespace Server.Services
{
    public class SearchAfter : ISearch
    {
        public List<Check> SearchChecks(DateTime selectedDate)
        {
            //MyLogger.Instance().Log("Search Checks After -- CALLED", "Service", "INFO");
            List<Check> searchResult = new List<Check>();
            using(ProjectDBContext dbContext = new ProjectDBContext())
            {
                foreach (Check c in dbContext.Checks)
                {
                    if (c.Datetime.Date > selectedDate.Date)
                        searchResult.Add(c);
                }
            }

            return searchResult;
        }
    }
}
