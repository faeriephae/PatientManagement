using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace PatientManagement.BusinessLayer
{
    /// <summary>
    /// Very simple error handling.
    /// </summary>
    public static class ErrorHandling
    {
        /// <summary>
        /// Writes error message to debug output window.
        /// </summary>
        /// <param name="e">Error.</param>
        public static void ErrorMsg(Exception e)
        {
            Debug.WriteLine($"\n Hi, \n {e.Message} \n Caused by {e.InnerException} \n Thrown by {e.TargetSite} \n (ノಠ益ಠ)ノ彡┻━┻ \n");
        }
    }
}
