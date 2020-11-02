using Common.Helpers;
using Common.Models;
using Server.DatabaseAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Services
{
    public class SearchBefore: ISearch
    {
        public List<Check> SearchChecks(DateTime selectedDate)
        {
            //MyLogger.Instance().Log("Search checks Before -- CALLED", "Service", "INFO");
            List<Check> searchResult = new List<Check>();
            using (ProjectDBContext dbContext = new ProjectDBContext())
            {
                foreach (Check c in dbContext.Checks)
                {
                    if (c.Datetime.Date < selectedDate.Date)
                        searchResult.Add(c);
                }
            }

            return searchResult;
        }
    }
}
